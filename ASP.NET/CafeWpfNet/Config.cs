using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeWpfEFCore
{
    public static class Config
    {
        static IConfigurationRoot? configurationRoot;
        public static IConfigurationRoot Configuration 
        {
            get 
            {
                if (configurationRoot == null)
                {
                    var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
                    //Determines the working environment as IHostingEnvironment is unavailable in a console app
                    var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                         devEnvironmentVariable.ToLower() == "development";
                    var builder = new ConfigurationBuilder();
                    // tell the builder to look for the appsettings.json file
                    builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    //only add secrets in development
                    if (isDevelopment)
                    {
                        builder.AddUserSecrets<App>();
                    }
                    configurationRoot = builder.Build();
                    
                }
                return configurationRoot;
            }
        }

        public static CafeWpfNet.DataAdapter DataAdapter = new CafeWpfNet.DataAdapter();

       
        public static int UserId { get; set; }
        public static string UserName { get; set; }

    }
}
