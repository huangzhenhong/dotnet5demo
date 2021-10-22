using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5.WebApi.AzureRedisDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;
        private static IConfiguration Configuration { get; set; }

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            if (Configuration == null)
                Configuration = configuration;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            if (CacheHelper.Connection == null) {
                await CacheHelper.InitializeAsync();
            }

            IDatabase cache = await CacheHelper.GetDatabaseAsync();
            // Perform cache operations using the cache object...

            // Simple PING command
            string command1 = "PING";
            string command1Result = cache.Execute(command1).ToString();

            cache.StringGet("Message").ToString();
            cache.StringSet("Message", "Hello! The cache is working from ASP.NET Core!", TimeSpan.FromDays(1)).ToString();
            string command4Result = cache.StringGet("Message").ToString();

            // Get the client list, useful to see if connection list is growing...
            // Note that this requires allowAdmin=true in the connection string
            //string command5 = "CLIENT LIST";
            //StringBuilder sb = new StringBuilder();
            //var endpoint = (System.Net.DnsEndPoint)(await CacheHelper.GetEndPointsAsync())[0];
            //IServer server = await CacheHelper.GetServerAsync(endpoint.Host, endpoint.Port);
            //ClientInfo[] clients = await server.ClientListAsync();

            //sb.AppendLine("Cache response :");
            //foreach (ClientInfo client in clients)
            //{
            //    sb.AppendLine(client.Raw);
            //}

            //string command5Result = sb.ToString();

            return command4Result;
        }
    }
}
