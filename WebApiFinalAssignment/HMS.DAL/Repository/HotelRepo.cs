using System;
using System.Collections.Generic;
using System.Linq;
using HMS.DAL.Database;
using Hotel = HMS.Models.Hotel;

namespace HMS.DAL.Repository
{
    public class HotelRepo : IHotelRepo
    {
        private readonly HMSContext _dbContext;

        public HotelRepo(HMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Hotel GetHotel(int id)
        {
            var entity = _dbContext.Hotels.FirstOrDefault(e => e.Id == id);

            if (entity != null)
                return new Hotel
                {
                    Id = entity.Id,
                    HotelName = entity.HotelName,
                    Address = entity.Address,
                    City = entity.City,
                    PinCode = entity.PinCode,
                    ContactPerson = entity.ContactPerson,
                    ContactNumber = entity.ContactNumber,
                    Website = entity.Website,
                    Facebook = entity.Facebook,
                    Twitter = entity.Twitter,
                    IsActive = entity.IsActive,
                    CreatedDate = entity.CreatedDate,
                    CreatedBy = entity.CreatedBy,
                    UpdatedDate = entity.UpdatedDate,
                    UpdatedBy = entity.UpdatedBy
                };

            throw new Exception("No Hotel found with given id");
        }

        public List<Hotel> GetAllHotel()
        {
            var hotels = new List<Hotel>();

            var entities = _dbContext.Hotels.OrderBy(e => e.HotelName).ToList();

            if (entities.Count > 0)
                foreach (var item in entities)
                    hotels.Add(new Hotel
                    {
                        Id = item.Id,
                        HotelName = item.HotelName,
                        Address = item.Address,
                        City = item.City,
                        PinCode = item.PinCode,
                        ContactPerson = item.ContactPerson,
                        ContactNumber = item.ContactNumber,
                        Website = item.Website,
                        Facebook = item.Facebook,
                        Twitter = item.Twitter,
                        IsActive = item.IsActive,
                        CreatedDate = item.CreatedDate,
                        CreatedBy = item.CreatedBy,
                        UpdatedDate = item.UpdatedDate,
                        UpdatedBy = item.UpdatedBy
                    });

            return hotels;
        }

        public Hotel CreateHotel(Hotel model)
        {
            var entity = _dbContext.Hotels.Add(new Database.Hotel
            {
                HotelName = model.HotelName,
                Address = model.Address,
                City = model.City,
                PinCode = model.PinCode,
                ContactPerson = model.ContactPerson,
                ContactNumber = model.ContactNumber,
                Website = model.Website,
                Facebook = model.Facebook,
                Twitter = model.Twitter,
                IsActive = model.IsActive,
                CreatedDate = DateTime.Now,
                CreatedBy = model.CreatedBy
            });

            _dbContext.SaveChanges();

            return new Hotel
            {
                Id = entity.Id,
                HotelName = entity.HotelName,
                Address = entity.Address,
                City = entity.City,
                PinCode = entity.PinCode,
                ContactPerson = entity.ContactPerson,
                ContactNumber = entity.ContactNumber,
                Website = entity.Website,
                Facebook = entity.Facebook,
                Twitter = entity.Twitter,
                IsActive = entity.IsActive,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy
            };
        }
    }
}