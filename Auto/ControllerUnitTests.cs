using Auto_Common.Models;
using Auto_Server.Controllers;
using Moq;
using Nest;
using System;
using Xunit;

namespace Auto
{
    public class ControllerUnitTests
    {
        [Fact]
        public void Delete_WithExistingId_RemoveOneClient()
        {

            //Arrange
            const int id = 1;
            var mockRepository = new Mock<MClient>();
            var controller = new MClientController();
            controller.Delete(id);


        }
    }
}
