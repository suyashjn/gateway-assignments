using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SourceControlFinalAssignment.DBContext;
using SourceControlFinalAssignment.Models;
using BC = BCrypt.Net.BCrypt;

namespace SourceControlFinalAssignment.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        
        public int AuthenticateUser(string signInEmail, string signInPassword)
        {
            User user = _db.Users.FirstOrDefault(u => u.Email == signInEmail);

            if (user == null || !BC.Verify(signInPassword, user.Password))
                return -1;
            return user.Id;
        }

        
        public bool IfEmailAlreadyExits(string signUpEmail)
        {
            return _db.Users.Any(u => u.Email == signUpEmail);
        }

        public async void StoreUserImage(IFormFile formFile, string imagePath)
        {
            using (var stream = System.IO.File.Create(imagePath))
            {
                await formFile.CopyToAsync(stream);
            }
        }
        
        public void AddUserToDb(UserSignUp userSignUp)
        {
            var imagePath = $"C:/user images/{userSignUp.Email}{Path.GetExtension(userSignUp.UserImage.FileName)}";
            
            StoreUserImage(userSignUp.UserImage, imagePath);
            
            var user = new User
            {
                FirstName = userSignUp.FirstName,
                LastName = userSignUp.LastName,
                ImagePath = imagePath,
                PhoneNumber = userSignUp.PhoneNumber,
                Email = userSignUp.Email,
                Password = BC.HashPassword(userSignUp.Password)
            };

            _db.Users.Add(user);
            _db.SaveChanges();
        }

        
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(UserSignIn userSignIn)
        {
            if (ModelState.IsValid)
            {
                int userId = AuthenticateUser(userSignIn.Email, userSignIn.Password);
                if (userId != -1)
                {
                    return RedirectToAction("Dashboard", _db.Users.First(u => u.Id == userId));
                }

                ModelState.AddModelError("NotFound", "Invalid email-id or password!");
            }

            return View(userSignIn);
        }

        
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(UserSignUp userSignUp)
        {
            if (ModelState.IsValid)
            {
                if (!IfEmailAlreadyExits(userSignUp.Email))
                {
                    AddUserToDb(userSignUp);
                    return RedirectToAction("Dashboard", userSignUp);
                }

                ModelState.AddModelError("EmailExits", "Email-id already in use");
            }

            return View(userSignUp);
        }

        
        public IActionResult Dashboard(User user)
        {
            return View(user);
        }
    }
}
