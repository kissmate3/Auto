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
            //
            var aclient = MClientRepository.GetMClients().ToList();

            //Assert
            Assert.NotEmpty(aclient);

        }
    }
}
