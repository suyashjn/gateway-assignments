using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using PMT.WebApi.Filters;
using Xunit;

namespace PMT.UnitTests.WebApi
{
    public class ValidateModelActionFilterTest
    {
        private readonly ValidateModelAttribute _validateModelAttribute = new ValidateModelAttribute();

        [Fact]
        public void ValidateModelAttributes_ReturnsBadRequest_WhenModelIsInvalid()
        {
            // Arrange
            var context = new HttpActionContext();
            context.ModelState.AddModelError("Name", "Name is invalid");
            var request = new HttpRequestMessage();
            var controllerContext = new HttpControllerContext { Request = request };
            context.ControllerContext = controllerContext;

            // Act
            _validateModelAttribute.OnActionExecuting(context);

            // Assert
            var responseMessage = Assert.IsType<HttpResponseMessage>(context.Response);
            Assert.Equal(HttpStatusCode.BadRequest, responseMessage.StatusCode);

            dynamic errMsg = responseMessage.Content.ReadAsAsync<object>().Result;
            Assert.Equal("Name is invalid", errMsg.ModelState["Name"][0]);
        }

        [Fact]
        public void ValidateModelAttributes_ReturnsBadRequest_WhenModelIsNull()
        {
            // Arrange
            var context = new HttpActionContext();
            context.ActionArguments["model"] = null;
            var request = new HttpRequestMessage();
            var controllerContext = new HttpControllerContext { Request = request };
            context.ControllerContext = controllerContext;

            // Act
            _validateModelAttribute.OnActionExecuting(context);

            // Assert
            var responseMessage = Assert.IsType<HttpResponseMessage>(context.Response);
            Assert.Equal(HttpStatusCode.BadRequest, responseMessage.StatusCode);

            dynamic errMsg = responseMessage.Content.ReadAsAsync<object>().Result;
            Assert.Equal("model is null", errMsg.Message);
        }
    }
}