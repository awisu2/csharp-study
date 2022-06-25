using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerAppNet5
{
    public class Program
    {
        class ParsedArgs
        {
            public string port;
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // set parse arg
                    var _args = ParseArgs(args);

                    webBuilder.UseStartup<Startup>();

                    // set urls
                    var urls = new string[] { "http://0.0.0.0:8080", "http://localhost:5003" };
                    if (!String.IsNullOrEmpty(_args.port))
                    {
                        var _urls = new List<string>(urls);
                        _urls.Add("http://0.0.0.0:" + _args.port);
                        urls = _urls.ToArray();
                    }
                    webBuilder.UseUrls(urls);
                });

        private static ParsedArgs ParseArgs(string[] args)
        {
            var parsedArgs = new ParsedArgs();

            var _port = Array.Find(args, arg => arg.StartsWith("p:"));
            if (!String.IsNullOrEmpty(_port))
            {
                parsedArgs.port = _port.Substring(2);
            }

            return parsedArgs;
        }
    }
}
