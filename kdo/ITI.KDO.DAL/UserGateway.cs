using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Linq;

namespace ITI.KDO.DAL
{
    public class UserGateway
    {
        readonly string _connectionString;
        public UserGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreatePasswordUser(string email, string firstName, string lastName, DateTime birthdate, string phone, byte[] password, string photo)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sUserAddPassword",
                    new
                    {
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        Birthdate = birthdate,
                        Phone = phone,
                        Password = password,
                        Photo = photo
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }


        //public IEnumerable<string> GetAuthenticationProviders(string userId)
        //{
        //    using(SqlConnection con = new SqlConnection(_connectionString))
        //    {
        //        return con.Query<string>(
        //            "select p.ProviderName from dbo.vAuthenticationProvider p where p.UserId = @UserId",
        //            new { UserId = userId });
        //    }
        //}

        //public User FindByGoogleId(string googleId)
        //{
        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    {
        //        return con.Query<User>(
        //                "select u.UserId, u.FirstName, u.LastName, u.Birthdate,u.Email, u.Phone, u.Photo, u.[Password], u.GoogleRefreshToken, u.GoogleId, u.FacebookRefreshToken, u.FacebookId from dbo.vUser u where u.GoogleId = @GoogleId",
        //                new { GoogleId = googleId })
        //            .FirstOrDefault();
        //    }
        //}


        public User FindByFacebookId(string facebookId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                        "select u.UserId, u.FirstName, u.LastName, u.Birthdate,u.Email, u.Phone, u.Photo, u.[Password], u.GoogleRefreshToken, u.GoogleId, u.FacebookAccessToken, u.FacebookId from dbo.vUser u where u.FacebookId = @FacebookId",
                        new { FacebookId = facebookId })
                    .FirstOrDefault();
            }
        }

        //public User FindByFacebookId(string facebookId)
        //{
        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    {
        //        return con.Query<User>(
        //                "select u.UserId, u.FirstName, u.LastName, u.Birthdate,u.Email, u.Phone, u.Photo, u.[Password], u.GoogleRefreshToken, u.FacebookRefreshToken from dbo.vUser u where u.FacebookId = @FacebookId",
        //                new { FacebookId = facebookId })
        //            .FirstOrDefault();
        //    }
        //}


        public void CreateGoogleUser(string email,string refreshToken)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sGoogleUserCreate",
                    new { Email = email, RefreshToken = refreshToken, FirstName = "N", LastName = "N" },
                    commandType: CommandType.StoredProcedure);
            }
        }
        
        public void CreateFacebookUser(string email, string facebookId, string accessToken)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sFacebookUserCreate",
                    new { Email = email, FacebookId = facebookId, AccessToken = accessToken, FirstName = "N", LastName = "N" },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                    @"select u.UserId,
                             u.FirstName,
                             u.LastName,
                             u.BirthDate,
                             u.Email,
                             u.Phone,
                             u.Photo
                      from dbo.vUser u;");
            }
        }

        public User FindUserPasswordHashed(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                    @"select [Password]
                      from dbo.tPasswordUser
                      where UserId = @UserId",
                    new { UserId = userId })
                    .FirstOrDefault();
            }
        }

        public User FindById(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                    @"select u.UserId,
                             u.FirstName,
                             u.LastName,
                             u.Email,
                             u.BirthDate,
                             u.Phone,
                             u.Photo,
                             u.FacebookAccessToken,
                             u.GoogleRefreshToken
                      from dbo.vUser u
                      where UserId = @UserId",
                    new { UserId = userId })
                    .FirstOrDefault();
            }
        }

        public User FindByEmail(string email)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                    @"select u.UserId,
                             u.FirstName,
                             u.LastName,
                             u.Email,
                             u.BirthDate,
                             u.Phone,
                             u.Photo,
                             u.FacebookAccessToken,
                             u.GoogleRefreshToken
                      from dbo.vUser u
                      where Email = @Email",
                    new { Email = email })
                    .FirstOrDefault();
            }
        }

        public void Create(string firstName, string lastName, DateTime birthDate, string email, string phone, string photo)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sUserCreate",
                    new { FirstName = firstName, LastName = lastName, Email = email, BirthDate = birthDate, Phone = phone },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sUserDelete",
                    new { UserId = userId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(int userId, string firstName, string lastName, DateTime birthDate, string email, string phone, string photo)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sUserUpdate",
                    new { UserId = userId, FirstName = firstName, LastName = lastName, BirthDate = birthDate, Email = email, Phone = phone, Photo = photo },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdatePassword(int userId, byte[] password)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sPasswordUserUpdate",
                    new { UserId = userId, Password = password },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateGoogleToken(int userId, string refreshToken)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sGoogleUserUpdate",
                    new { UserId = userId, refreshToken = refreshToken },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateFacebookToken(int userId, string facebookId, string accessToken)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sFacebookUserUpdate",
                    new { UserId = userId, FacebookId = facebookId, AccessToken = accessToken },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void AddGoogleToken(int userId, string refreshToken)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sUserAddGoogleToken",
                    new { UserId = userId, RefreshToken = refreshToken },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void AddFacebookToken(int userId, string facebookId, string accessToken)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sUserAddFacebookToken",
                    new { UserId = userId, FacebookId = facebookId, AccessToken = accessToken },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<string> GetAuthenticationProviders(string userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<string>(
                    "select p.ProviderName from dbo.vAuthenticationProvider p where p.UserId = @UserId",
                    new { UserId = userId });
            }
        }

    }
}
