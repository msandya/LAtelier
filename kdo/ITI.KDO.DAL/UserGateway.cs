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

        public void CreatePasswordUser(string mail, string firstName, string lastName, DateTime birthdate, string phone, byte[] password, string photo)
        {
            using(SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sPasswordUserCreate",
                    new {
                        Mail = mail,
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

        /*public IEnumerable<string> GetAuthenticationProviders(string userId)
        {
            using(SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<string>(
                    "select p.ProviderName from dbo.vAuthenticationProvider p where p.UserId = @UserId",
                    new { UserId = userId });
            }
        }*/

        public IEnumerable<User> GetAll()
        {
            using(SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                    @"select u.UserId,
                             u.FirstName,
                             u.LastName,
                             u.Mail,
                             u.Birthdate,
                             u.Phone,
                             u.Photo
                      from dbo.vUser u;");
            }
        }

        /*public User FindUserPasswordHashed(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                    @"select u.Password
                      from dbo.vUser u
                      where UserId = @UserId",
                    new { UserId = userId })
                    .FirstOrDefault();
            }
        }*/

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
                             u.Mail,
                             u.Birthdate,
                             u.Phone,
                             u.Photo
                      from dbo.vUser u
                      where UserId = @UserId",
                    new { UserId = userId })
                    .FirstOrDefault();
            }
        }

        public User FindByMail(string mail)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                    @"select u.UserId,
                             u.FirstName,
                             u.LastName,
                             u.Mail,
                             u.Birthdate,
                             u.Phone,
                             u.Photo
                      from dbo.vUser u
                      where Mail = @Mail",
                    new { Mail = mail })
                    .FirstOrDefault();
            }
        }

        //public User FindByPseudo(string pseudo)
        //{
        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    {
        //        return con.Query<User>(
        //            @"select u.UserId,
        //                     u.Pseudo,
        //                     u.FirstName,
        //                     u.LastName,
        //                     u.Mail,
        //                     u.BirthDate,
        //                     u.PhoneTel
        //              from dbo.vUser u
        //              where Pseudo = @Pseudo",
        //            new { Pseudo = pseudo })
        //            .FirstOrDefault();
        //    }
        //}

        public void Create( string firstName, string lastName, string mail, DateTime birthdate, string phone, string photo)
        {
            using(SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sUserCreate",
                    new {  FirstName = firstName, LastName = lastName, Mail = mail, BirthDate = birthdate, Phone = phone, Photo = photo },
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

        public void Update(int userId, string firstName, string lastName, string mail, DateTime birthdate, string phone, string photo)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "sUserUpdate",
                    new { UserId = userId, FirstName = firstName, LastName = lastName, Mail = mail, Birthdate = birthdate, Phone = phone, Photo = photo },
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
    }
}
