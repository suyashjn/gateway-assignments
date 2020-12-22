using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace SourceControlFinalAssignment.CustomValidation
{
    public class CustomFileExtValidation : ValidationAttribute
    {
        public List<string> Extensions { get; set; }
        public new string ErrorMessage { get; set; } = "Please upload right type of file";

        public CustomFileExtValidation(string extensions)
        {
            Extensions = extensions.Split(' ').ToList();
        }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var ext = Path.GetExtension(((IFormFile)value).FileName).ToLowerInvariant().Remove(0, 1);
            if (string.IsNullOrEmpty(ext) || !Extensions.Contains(ext))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}