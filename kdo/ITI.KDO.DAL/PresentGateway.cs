using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ITI.KDO.DAL
{
    public class PresentGateway
    {
        readonly string _connectionString;

        public PresentGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Present FindById(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Present>(
                    @"select
		            UserId = p.UserId,
		            PresentId = p.PresentId,
		            PresentName = p.PresentName,
		            Price = p.Price,
		            LinkPresent = p.LinkPresent		
	                from dbo.vUserPresent p
                    where p.UserId = @UserId",
                    new { UserId = userId })
                    .FirstOrDefault();
            }
        }
        public IEnumerable<Present> UserPresent()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Present>(
                    @"select p.UserId,
                             p.CategoryPresentId,
                             p.LinkPresent,
                             p.PresentId,
                             p.PresentName,
                             p.Price
                      from dbo.vUserPresent p
                      where p.UserId = @UserId;");
            }
        }

        public void AddUserPresent(string presentName, float price, string linkPresent, int categoryPresentId, int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sAddUserPresent",
                    new
                    {
                        PresentName = presentName,
                        Price = price,
                        LinkPresent = linkPresent,
                        categoryPresentId = categoryPresentId,
                        UserId = userId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        //public void DeleteUserPresent()
        //{
        //    using ()
        //    {

        //    }
        //}

        //public void UpdateUserPresent()
        //{
        //    using ()
        //    {

        //    }
        //}

    }
}
