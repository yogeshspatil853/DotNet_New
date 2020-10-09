using LifeInsuranceAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace UnitTestLifeInsurance
{
    public class TestClientProvider : IDisposable
    {
        public TestServer server;
        public HttpClient client { get; private set; }
        public TestClientProvider()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            client = server.CreateClient();
        }
        public void Dispose()
        {
            server?.Dispose();
            client?.Dispose();
        }
    }
}
