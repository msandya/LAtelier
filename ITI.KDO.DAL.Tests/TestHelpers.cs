using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITI.KDO.DAL.Tests
{
    public class TestHelpers
    {
        static readonly Random _random = new Random();
        static IConfiguration _configuration;


        public static string ConnectionString
        {
            get
            {
                return Configuration["ConnectionStrings:KDODB"];
            }
        }

        static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true)
                        .AddEnvironmentVariables()
                        .Build();
                }

                return _configuration;
            }
        }

        public static string RandomTestName() => string.Format("Test-{0}", Guid.NewGuid().ToString().Substring(24));

        public static DateTime RandomBirthDate(int age) => DateTime.UtcNow.AddYears(-age).AddMonths(_random.Next(-11, 0)).Date;

        public static string RandomEmail() => string.Format("user{0}@test.com", Guid.NewGuid()).ToString().Substring(0, 8);

        public static string RandomPresentName() => string.Format("Test-{0}", Guid.NewGuid().ToString().Substring(24));

    }
}
