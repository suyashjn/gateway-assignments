using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using PMT.Business.Interface;
using PMT.Core.Dto;
using PMT.WebApi.Controllers;
using Xunit;

namespace PMT.UnitTests.WebApi
{
    public class PassengerControllerTests
    {
        private readonly Mock<IPassengerManager> _mockPassengerManager = new();
        private readonly PassengerController _passengerController;

        public PassengerControllerTests()
        {
            _passengerController = new PassengerController(_mockPassengerManager.Object);
        }


        // Add New Passenger
        [Fact]
        public async Task PostPassenger_ReturnsCreatedResult_WhenModelStateIsValid()
        {
            // Arrange
            var passenger = new PassengerDto { FirstName = "Suyash", LastName = "Jain", MobileNo = "9624614874" };
            _mockPassengerManager.Setup(x => x.AddPassenger(passenger)).ReturnsAsync(new PassengerDto
            {
                Id = 1,
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                MobileNo = passenger.MobileNo,
            });

            // Act
            var result = await _passengerController.PostPassenger(passenger);

            // Assert
            var createdNegResult = Assert.IsType<CreatedNegotiatedContentResult<PassengerDto>>(result);
            Assert.Equal("DefaultApi", createdNegResult.Location.ToString());
        }


        // Get List of all Passengers
        [Fact]
        public void GetPassengers_ReturnsListOfPassenger()
        {
            // Arrange
            _mockPassengerManager.Setup(x => x.GetPassengers()).Returns(GetAllPassenger());

            // Act
            var actualResult = _passengerController.GetPassengers();

            // Assert
            Assert.Equal(3, actualResult.Count());
        }


        // Get Passenger By Id
        [Fact]
        public async Task GetPassenger_ReturnsOkResultWithPassenger_WhenPassengerWithIdExists()
        {
            // Arrange
            var id = 1;
            var passenger = new PassengerDto
            {
                Id = id,
                FirstName = "Suyash",
                LastName = "Jain",
                MobileNo = "9624614874"
            };
            _mockPassengerManager.Setup(x => x.GetPassenger(id)).ReturnsAsync(passenger);

            // Act
            var result = await _passengerController.GetPassenger(1);

            // Assert
            var okNegResult = Assert.IsType<OkNegotiatedContentResult<PassengerDto>>(result);
            Assert.Equal(id, okNegResult.Content.Id);
        }

        [Fact]
        public async Task GetPassenger_ReturnsNotFoundResult_WhenPassengerWithIdDoNotExists()
        {
            // Arrange
            // Nothing to do here

            // Act
            var result = await _passengerController.GetPassenger(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }


        // Update an Passenger
        [Fact]
        public async Task PutPassenger_ReturnNoContentResult_WhenPassengerIsUpdatedSuccessfully()
        {
            // Arrange
            var id = 1;
            var passenger = new PassengerDto
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                MobileNo = "9426836645"
            };
            _mockPassengerManager.Setup(x => x.UpdatePassenger(passenger)).ReturnsAsync(true);

            // Act
            var result = await _passengerController.PutPassenger(id, passenger);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(HttpStatusCode.NoContent, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task PutPassenger_ReturnNotFoundResult_WhenPassengerWithIdDoNotExists()
        {
            // Arrange
            var id = 1;
            var passenger = new PassengerDto
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                MobileNo = "9426836645"
            };
            _mockPassengerManager.Setup(x => x.UpdatePassenger(passenger)).ReturnsAsync(false);

            // Act
            var result = await _passengerController.PutPassenger(id, passenger);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }


        // Delete any existing Passenger.
        [Fact]
        public async Task DeletePassenger_ReturnsNoContentResult_WhenPassengerDeletedSuccessfully()
        {
            //Arrange
            var id = 1;
            _mockPassengerManager.Setup(x => x.DeletePassenger(id)).ReturnsAsync(true);

            //Act
            var result = await _passengerController.DeletePassenger(id);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(HttpStatusCode.NoContent, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task DeletePassenger_ReturnsNotFoundResult_WhenPassengerWithIdDoNotExists()
        {
            //Arrange
            _mockPassengerManager.Setup(x => x.DeletePassenger(1)).ReturnsAsync(false);

            //Act
            var result = await _passengerController.DeletePassenger(1);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }


        //Static List of Passengers
        private static IQueryable<PassengerDto> GetAllPassenger()
        {
            var users = new List<PassengerDto>
            {
                new() {Id=1, FirstName="Suyash", LastName="Jain", MobileNo="9624614874"},
                new() {Id=2, FirstName="Suyash1", LastName="Jain", MobileNo="9575813776"},
                new() {Id=3, FirstName="Suyash2", LastName="Jain", MobileNo="9575813770"},
            };

            return users.AsQueryable();
        }
    }
}

