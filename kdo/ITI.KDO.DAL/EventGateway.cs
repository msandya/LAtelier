using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ITI.KDO.DAL
{
    public class EventGateway
    {
        readonly string _connectionString;

        public EventGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        ///<summary>
        ///Find Event of User with UserId
        ///</summary>
        ///<param name="userId"></param>
        ///<returns></return>
        public Event FindById(int eventId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Event>(
                    @"select e.UserId,
                             e.EventId,
                             e.EventName,
                             e.Descriptions,
                             e.Dates
                          from dbo.vEvent e
                          where e.EventId = @EventId",
                          new { EventId = eventId })
                          .FirstOrDefault(); 
            }
        }

        /// <summary>
        /// Add Event to User and return the EventId
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="description"></param>
        /// <param name="dates"></param>
        /// <param name="userId"></param>
        public int AddToUser(string eventName, string description, DateTime dates, int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EventName", eventName, DbType.String);
                dynamicParameters.Add("@Description", description, DbType.String);
                dynamicParameters.Add("@Dates", dates, DbType.DateTime2);
                dynamicParameters.Add("@UserId", userId, DbType.Int32);
                dynamicParameters.Add("@EventId", DbType.Int32, direction: ParameterDirection.ReturnValue);

                con.Execute(
                    "dbo.sEventCreate",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure
                );
                return dynamicParameters.Get<int>("@EventId");
            }
        }

        /// <summary>
        /// Update Event Of User
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="descriptions"></param>
        /// <param name="dates"></param>
        /// <param name="userId"></param>
        public void Update(int eventId, string eventName, string descriptions,DateTime dates, int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
               "dbo.sEventUpdate",
               new
               {
                   EventId = eventId,
                   EventName = eventName,
                   Descriptions = descriptions,
                   Dates = dates,
                   UserId = userId
               },
               commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Delete Event Of User
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="userId"></param>
        public void Delete(int eventId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sEventDelete",
                    new { EventId = eventId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Event> GetAllByUserId(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Event>(
                    @"select e.UserId,
                             e.EventName,
                             e.Descriptions,
                             e.Dates
                      from dbo.vEvent e
                      where e.UserId = @UserId;",
                    new { UserId = userId });
            }
        }

        public void Create(string eventName, string descriptions, DateTime dates, int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sEventCreate",
                    new
                    {
                        EventName = eventName,
                        Descriptions = descriptions,
                        Dates = dates,
                        UserId = userId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(string eventName, string descriptions, DateTime dates, int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dbo.sEventUpdate",
                    new
                    {
                        EventName = eventName,
                        Descriptions = descriptions,
                        Dates = dates,
                        UserId = userId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Event FindByEventId(int eventId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Event>(
                          @"select e.UserId,
                             e.EventName,
                             e.Descriptions,
                             e.Dates
                      from dbo.vEvent e
                      where e.EventId = @EventId;",
                        new { EventId = eventId })
                    .FirstOrDefault();
            }
        }


        public Event FindByName(string eventName)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Event>(
                          @"select e.UserId,
                             e.EventName,
                             e.Descriptions,
                             e.Dates
                      from dbo.vEvent e
                      where e.EventId = @EventId;",
                        new { EventName = eventName })
                    .FirstOrDefault();
            }
        }


    }
}
