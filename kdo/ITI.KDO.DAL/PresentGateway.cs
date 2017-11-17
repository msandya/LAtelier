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

        /// <summary>
        /// Find Present Of User with UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Present FindById(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Present>(
                    @"select p.UserId,
		                     p.PresentId,
		                     p.PresentName,
		                     p.Price,
                             p.CategoryPresentId,
		                     p.LinkPresent		
	                from dbo.vUserPresent p
                    where p.UserId = @UserId",
                    new { UserId = userId })
                    .FirstOrDefault(); ;
            }
        }
        /// <summary>
        /// Add Present to User and return the PresentId
        /// </summary>
        /// <param name="presentName"></param>
        /// <param name="price"></param>
        /// <param name="linkPresent"></param>
        /// <param name="categoryPresentId"></param>
        /// <param name="userId"></param>
        public int AddToUser(string presentName, float price, string linkPresent, int categoryPresentId, int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@PresentName", presentName, DbType.String);
                dynamicParameters.Add("@Price", price, DbType.Decimal);
                dynamicParameters.Add("@LinkPresent", linkPresent, DbType.String);
                dynamicParameters.Add("@CategoryPresentId", categoryPresentId, DbType.Int32);
                dynamicParameters.Add("@UserId", userId, DbType.Int32);
                dynamicParameters.Add("@PresentId",DbType.Int32, direction: ParameterDirection.ReturnValue);

                con.Execute(
                    "dbo.sAddUserPresent",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure
                );
                return dynamicParameters.Get<int>("@PresentId");
            }
        }
        /// <summary>
        /// Update Present Of User
        /// </summary>
        /// <param name="presentName"></param>
        /// <param name="price"></param>
        /// <param name="linkPresent"></param>
        /// <param name="categoryPresentId"></param>
        /// <param name="userId"></param>
        public void Update(string presentName, float price, string linkPresent, int categoryPresentId, int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
               "dbo.sUpdatePresent",
               new { PresentName = presentName, Price = price, linkPresent = linkPresent, categoryPresentId = categoryPresentId, userId = userId },
               commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Delete Present Of User
        /// </summary>
        /// <param name="presentId"></param>
        /// <param name="userId"></param>
        public void Delete(int presentId, int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sDeletePresent",
                    new { PresentId = presentId, UserId = userId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
