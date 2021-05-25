using Auto_Common.Models;
using Auto_Server.Controllers;
using Moq;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            const int id = 1;
            var mockRepository = new Mock<MClient>();
            var controller = new MClientController();
            controller.Delete(id);

        }
    }
}
