using System;
using System.Data.Entity.Migrations;
using SBS.Data.Models;

namespace SBS.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SBSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SBSDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Dealers.AddOrUpdate(x => x.Id,
                new Dealer
                {
                    Id = 1,
                    Name = "Suyash Jain D1",
                    Address = "3137  Lee Avenue",
                    City = "Mandsaur",
                    State = "MP",
                    Zipcode = 458002,
                    Email = "suyashjaind1@gmail.com",
                    Mobile = "9999999991",
                    Password = "passwordd1"
                },
                new Dealer
                {
                    Id = 2,
                    Name = "Suyash Jain D2",
                    Address = "3138  Lee Avenue",
                    City = "Mandsaur",
                    State = "MP",
                    Zipcode = 458001,
                    Email = "suyashjaind2@gmail.com",
                    Mobile = "9999999992",
                    Password = "passwordd2"
                });

            context.Customers.AddOrUpdate(x => x.Id,
                new Customer
                {
                    Id = 1,
                    Name = "Suyash Jain C1",
                    Address = "4567  Lee Avenue",
                    City = "Mandsaur",
                    State = "MP",
                    Zipcode = 458001,
                    Email = "suyashjainc1@gmail.com",
                    Mobile = "9999999993",
                    Password = "passwordc1",
                    Question = "Favorite fruit",
                    Answer = "Mango"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Suyash Jain C2",
                    Address = "3627  Lee Avenue",
                    City = "Mandsaur",
                    State = "MP",
                    Zipcode = 458002,
                    Email = "suyashjainc2@gmail.com",
                    Mobile = "9999999994",
                    Password = "passwordc2",
                    Question = "Favorite fruit",
                    Answer = "Mango"
                });

            context.Vehicles.AddOrUpdate(x => x.Id,
                new Vehicle
                {
                    Id = 1, LicensePlate = "MP14MJ6767", Make = "Hero", Model = "Passion",
                    RegistrationDate = DateTime.Now, ChassisNo = "SGDUH678LP", OwnerId = 1
                },
                new Vehicle
                {
                    Id = 2, LicensePlate = "MP14Mj9024", Make = "TVS", Model = "Star City",
                    RegistrationDate = DateTime.Now, ChassisNo = "HDSHIS875K", OwnerId = 2
                });

            context.Mechanics.AddOrUpdate(x => x.Id,
                new Mechanic
                {
                    Id = 1,
                    Name = "Suyash Jain M1",
                    Mobile = "9999999995",
                    Make = "Hero",
                    Email = "suyashjainm1@gmail.com",
                    DealerId = 1
                },
                new Mechanic
                {
                    Id = 2,
                    Name = "Suyash Jain M2",
                    Mobile = "9999999996",
                    Make = "TVS",
                    Email = "suyashjainm2@gmail.com",
                    DealerId = 2
                });

            context.Services.AddOrUpdate(x => x.Id,
                new Service {Id = 1, Name = "Engine", Price = 2000, Duration = "5 Hr", Active = true},
                new Service {Id = 2, Name = "Bearing", Price = 4500, Duration = "2 Hr", Active = true},
                new Service {Id = 3, Name = "Oiling", Price = 3700, Duration = "6 Hr", Active = true});
        }
    }
}