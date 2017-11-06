using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.KDO.DAL
{
    public class User
    {
        public int UserId { get; set; }
     
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mail { get; set; }

        public DateTime Birthdate { get; set; }

        public string Phone { get; set; }

        public string Photo { get; set; }

        public byte[] Password { get; set; }
    }
}
