using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace UnitTestingDI.Test
{
    internal class TestApplication : WebApplicationFactory<UserInterface.Program>
    {
        private readonly Func<IHostBuilder, IHostBuilder> _configureHost;

        public TestApplication() { }

        public TestApplication(Func<IHostBuilder, IHostBuilder> configureHost)
        {
            _configureHost = configureHost;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            _configureHost?.Invoke(builder);
            return base.CreateHost(builder);
        }
    }
}
