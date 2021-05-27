using Auto_Common.Models;
using Auto_Server.Controllers;
using Auto_Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace ControllerTests
{
    public class ControllerUnitTest
    {
        [Fact]
        public void GetMclient_WithValidArgument_ClientListNotEmpty()
        {
            // Arrange
            var aclient = MClientRepository.GetMClients().ToList();

            //Assert
            Assert.NotEmpty(aclient);
        }

        [Fact]
        public void Get_WithInvalidId_ClientIsNull()
        {
            // Arrange
            var id = 1;

            // Act
            var clients = MClientRepository.GetMClients();
            var client = clients.FirstOrDefault(x => x.Id == id);

            // Assert
            Assert.Null(client);
        }

        [Fact]
        public void Get_WithValidId_ClientIsNotNull()
        {
            // Arrange
            var controller = new MClientController();

            // Act
            var response = controller.Get(5);

            // Assert
            Assert.NotNull(response);
        }

    }
}
