using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.KDO.DB.Tests
{
    [TestFixture]
    public class T2PresentManagement
    {
        static readonly string ConnectionString = @"Server=.\SQLEXPRESS;Database=ITI.KDO;Trusted_Connection=True;";

        [Test]
        public async Task T1_Display_Presents()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("select * from dbo.tPresent t where t.PresentId <> 0", con))
            {
                await con.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Console.WriteLine("PresentId: {0} - PresentName: {1} - Price: {2} - LinkPresent: {3} - CategoryPresentId: {4} - UserId: {5}",
                            reader["UserId"], reader["FirstName"], reader["LastName"], reader["Email"], reader["Phone"], reader["Birthdate"]);
                    }
                }
            }
        }
    }
}
