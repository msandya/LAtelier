using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ITI.KDO.DAL
{
    public class CategoryPresentGateway
    {
        readonly string _connectionString;

        public CategoryPresentGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Create(string categoryName, string link)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@categoryName", categoryName, DbType.String);
                dynamicParameters.Add("@Link", link, DbType.String);
                dynamicParameters.Add("@CategoryPresentId", DbType.Int32, direction: ParameterDirection.ReturnValue);

                con.Execute(
                    "dbo.sCategoryPresentCreate",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure
                );

                return dynamicParameters.Get<int>("@CategoryPresentId");
            }
        }
    }
}
