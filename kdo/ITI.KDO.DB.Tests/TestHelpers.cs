using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.KDO.DB.Tests
{
    public class TestHelpers
    {
        private static Random gen = new Random();

        public static DateTime RandomDay()
        {
            DateTime start = new DateTime(1990, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        public static string RandomName() => string.Format("Name-{0}", Guid.NewGuid().ToString().Substring(0, 8));

        public static string RandomEmail() => string.Format("{0}.@email.com", Guid.NewGuid().ToString().Substring(0, 8));

        public static string RandomPhoneNumber()
        {
            string phoneNum = "";
            for(int i = 0; i < 10; i++)
            {
                phoneNum += gen.Next(10).ToString();
            }
            return phoneNum;
        }

        public static void SetParameters(SqlCommand command, params object[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                command.Parameters.AddWithValue(string.Format("@{0}", i), args[i]);
            }
        }

        public static async Task AssertScalar(string text, SqlConnection con, object expected, params object[] args)
        {
            using (SqlCommand command = new SqlCommand(text, con))
            {
                SetParameters(command, args);
                Assert.That(await command.ExecuteScalarAsync(), Is.EqualTo(expected));
            }
        }
    }
}
