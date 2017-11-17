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

        /// <summary>
        /// Create User With a Password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        public void CreateUserWithPassword(string email, string firstName, string lastName, byte[] password)
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
                        Password = password
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Find User with the GoogleId
        /// </summary>
        /// <param name="googleId"></param>
        /// <returns></returns>
        public User FindByGoogleId(int googleId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                        @"select u.UserId,
                                u.FirstName,
                                u.LastName,
                                u.Birthdate,
                                u.Email,
                                u.Phone,
                                u.Photo,
                                u.[Password],
                                u.GoogleRefreshToken,
                                u.GoogleId,
                                u.FacebookRefreshToken,
                                u.FacebookId from dbo.vUser u
                          where u.GoogleId = @GoogleId",
                        new { GoogleId = googleId })
                    .FirstOrDefault();
            }
        }
            /// <summary>
            /// Find User with the FacebookId
            /// </summary>
            /// <param name="facebookId"></param>
            /// <returns></returns>
        public User FindByFacebookId(int facebookId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                        @"select u.UserId,
                                 u.FirstName,
                                 u.LastName,
                                 u.Birthdate,
                                 u.Email,
                                 u.Phone,
                                 u.Photo,
                                 u.[Password],
                                 u.GoogleRefreshToken,
                                 u.GoogleId,
                                 u.FacebookRefreshToken,
                                 u.FacebookId from dbo.vUser u
                         where u.FacebookId = @FacebookId",
                        new { FacebookId = facebookId })
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Create Google User
        /// </summary>
        /// <param name="email"></param>
        /// <param name="googleId"></param>
        /// <param name="refreshToken"></param>
        /// <param name="firstName"></param>
        /// <param name="lastname"></param>
        public void CreateGoogleUser(string email, string googleId, string refreshToken, string firstName, string lastname)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sGoogleUserCreate",
                    new { Email = email, GoogleId = googleId, RefreshToken = refreshToken, FirstName = firstName, lastname = lastname },
                    commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Create Facebook User
        /// </summary>
        /// <param name="email"></param>
        /// <param name="facebookId"></param>
        /// <param name="refreshToken"></param>
        /// <param name="firstName"></param>
        /// <param name="lastname"></param>
        public void CreateFacebookUser(string email, string facebookId, string refreshToken, string firstName, string lastname)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sFacebookUserCreate",
                    new { Email = email, FacebookId = facebookId, RefreshToken = refreshToken, FirstName = firstName, lastname = lastname },
                    commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Get All User
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Find User With PassWord Hashed
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Find User by the UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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
                             u.GoogleRefreshToken,
                             u.FacebookRefreshToken,
                             u.[Password],
                             u.Photo
                      from dbo.vUser u
                      where u.UserId = @UserId",
                    new { UserId = userId })
                    .FirstOrDefault();
            }
        }
        /// <summary>
        ///  Find User by the Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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
                             u.GoogleRefreshToken,
                             u.FacebookRefreshToken,
                             u.GoogleId,
                             u.[Password],
                             u.FacebookId
                      from dbo.vUser u
                      where u.Email = @Email",
                    new { Email = email })
                    .FirstOrDefault();
            }
        }
        /// <summary>
        /// Create User and Return This UserId
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="photo"></param>
        /// <returns></returns>
        public int Create(string firstName, string lastName, DateTime birthDate, string email, string phone, string photo)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FirstName", firstName, DbType.String);
                dynamicParameters.Add("@LastName", lastName, DbType.String);
                dynamicParameters.Add("@Email", email, DbType.String);
                dynamicParameters.Add("@BirthDate", birthDate, DbType.DateTime2);
                dynamicParameters.Add("@Phone", phone, DbType.String);
                dynamicParameters.Add("@Photo", photo, DbType.String);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.ReturnValue);

                con.Execute(
                    "dbo.sUserCreate",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure
                );

                return dynamicParameters.Get<int>("@Id");
            }
        }
        /// <summary>
        /// Delete User with this UserId
        /// </summary>
        /// <param name="userId"></param>
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
        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="photo"></param>
        public void Update(int userId, string firstName, string lastName, DateTime birthDate, string email, string phone, string photo)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sUpdateUser",
                    new { UserId = userId, FirstName = firstName, LastName = lastName, BirthDate = birthDate, Email = email, Phone = phone, Photo = photo },
                    commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Update Password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
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
        /// <summary>
        /// Update GoogleToken
        /// </summary>
        /// <param name="googleId"></param>
        /// <param name="refreshToken"></param>
        public void UpdateGoogleToken(string googleId, string refreshToken)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sGoogleUserUpdate",
                    new { GoogleId = googleId, RefreshToken = refreshToken },
                    commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Update FacebookToken
        /// </summary>
        /// <param name="facebookId"></param>
        /// <param name="refreshToken"></param>
        public void UpdateFacebookToken(string facebookId, string refreshToken)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sFacebookUserUpdate",
                    new { FacebookId = facebookId, RefreshToken = refreshToken },
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
