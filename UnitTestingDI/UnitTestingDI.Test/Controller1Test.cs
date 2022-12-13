using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;

namespace UnitTestingDI.Test
{
    public class Controller1Test
    {
        private readonly TestApplication _testApplication;

        public Controller1Test()
        {
            _testApplication = new TestApplication(builder =>
            {
                builder.ConfigureServices(s => s.AddScoped(CreateController1Mock));
                return builder;
            });
        }

        private IController1 CreateController1Mock(IServiceProvider arg)
        {
            var controller1Mock = new Mock<IController1>();
            controller1Mock.Setup(c => c.GetNumberThree()).Returns(5);
            return controller1Mock.Object;
        }

        [Fact]
        public void ConfigureMockTest()
        {
            using (var scope = _testApplication.Services.CreateScope())
            {
                var controller1 = scope.ServiceProvider.GetService<IController1>();
                Assert.Equal(5, controller1.GetNumberThree());
            }
        }

        [Fact]
        public void ConfigureMockTest2()
        {
            using (var scope = _testApplication.Services.CreateScope())
            {
                var controller1 = scope.ServiceProvider.GetService<IController2>();
                Assert.Equal(8, controller1.AddThreeToThree());
            }
        }
    }
}
