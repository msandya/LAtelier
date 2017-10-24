using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.KDO.DAL
{
    public class User
    {
        public int UserId { get; set; }

        public string Pseudo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneTel { get; set; }

        public byte[] Password { get; set; }
    }
}
