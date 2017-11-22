using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.KDO.DAL
{
    public class Event
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string Description { get; set; }

        public DateTime Dates { get; set; }

        public int UserId { get; set; }
    }
}
