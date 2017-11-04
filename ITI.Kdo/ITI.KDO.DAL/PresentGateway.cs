using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ITI.KDO.DAL
{
    class PresentGateway
    {
        readonly string _connectionString;

        public PresentGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Present> UserPresent()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Present>(
                    @"select p.UserId,
                             p.CategoryPresentId,
                             p.CategoryName,
                             p.Link,
                             p.PresentId,
                             p.PresentName,
                             p.Price,
                             p.LinkPresent
                      from dbo.vUserPresent p;");
            }
        }
    }
}
