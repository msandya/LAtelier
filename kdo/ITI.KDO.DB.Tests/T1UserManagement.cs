using ITI.KDO.DAL;
using NUnit.Framework;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.KDO.DB.Tests
{
    [TestFixture]
    public class T1UserManagement
    {
        static readonly string ConnectionString = @"Server=.\SQLEXPRESS;Database=ITI.KDO;Trusted_Connection=True;";

        [Test]
        public async Task T1_Display_Users()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("select * from dbo.tUser t where t.UserId <> 0", con))
            {
                await con.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Console.WriteLine("UserId: {0} - FirstName: {1} - LastName: {2} - Email: {3} - PhoneNumber: {4} - Birthdate: {5}", 
                            reader["UserId"], reader["FirstName"], reader["LastName"], reader["Email"], reader["Phone"], reader["Birthdate"]);
                    }
                } 
            }
        }

        [Test]
        public async Task T2_Get_User()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                await con.OpenAsync();
                List<User> originalUsers = await GetAllUsers(con);

                string firstName = TestHelpers.RandomName();
                string lastName = TestHelpers.RandomName();
                string email = TestHelpers.RandomEmail();
                DateTime birthdate = TestHelpers.RandomDay();
                string phone = TestHelpers.RandomPhoneNumber();
                string photo = TestHelpers.RandomName();

                using (SqlCommand command = new SqlCommand("dbo.sUserCreate", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Birthdate", birthdate);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Photo", photo);
                    await command.ExecuteNonQueryAsync();
                }

                List<User> currentUsers = await GetAllUsers(con);
                //Assert.That(originalUsers.All(t => currentUsers.Contains(t)));
                //Assert.That(currentUsers.Contains(new User(firstName, lastName, email, birthdate, phone, photo)));
                Assert.That(currentUsers.Count, Is.EqualTo(originalUsers.Count + 1));

                using (SqlCommand command = new SqlCommand("delete from dbo.tUser where FirstName = @FirstName and LastName = @LastName and Email = @Email and Birthdate = @Birthdate and Phone = @Phone and Photo = @Photo", con))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Birthdate", birthdate);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Photo", photo);
                    await command.ExecuteNonQueryAsync();
                }
                con.Close();
            }
        }

        [Test]
        public async Task T3_Create_Find_and_Remove_User()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string firstName = TestHelpers.RandomName();
                string lastName = TestHelpers.RandomName();
                string email = TestHelpers.RandomEmail();
                DateTime birthdate = TestHelpers.RandomDay();
                string phone = TestHelpers.RandomPhoneNumber();
                string photo = TestHelpers.RandomName();

                await con.OpenAsync();

                using(SqlCommand command = new SqlCommand("dbo.sUserCreate", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Birthdate", birthdate);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Photo", photo);
                    await command.ExecuteNonQueryAsync();
                }

                await TestHelpers.AssertScalar(
                    "select count(*) from dbo.vUser where FirstName = @0 and LastName = @1 and Email = @2 and Birthdate = @3 and Phone = @4 and Photo = @5",
                    con,
                    1,
                    firstName, lastName, email, birthdate, phone, photo);

                int userId;

                using(SqlCommand command = new SqlCommand("select UserId from dbo.vUser where FirstName = @0 and LastName = @1 and Email = @2 and Birthdate = @3 and Phone = @4 and Photo = @5", con))
                {
                    TestHelpers.SetParameters(command, firstName, lastName, email, birthdate, phone, photo);
                    userId = (int)await command.ExecuteScalarAsync();
                }

                using (SqlCommand command = new SqlCommand("dbo.sUserDelete", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }


        async Task<List<User>> GetAllUsers(SqlConnection con)
        {
            List<User> users = new List<User>();
            using (SqlCommand command = new SqlCommand("select u.FirstName, u.LastName, u.Email, u.Birthdate, u.Photo, u.Phone from dbo.tUser u where u.UserId <> 0;", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    users.Add(new User(
                        (string)reader["FirstName"], 
                        (string)reader["LastName"], 
                        (string)reader["Email"], 
                        (DateTime)reader["Birthdate"], 
                        (string)reader["Phone"], 
                        (string)reader["Photo"]));
                }
            }
            return users;
        }
    }
}
