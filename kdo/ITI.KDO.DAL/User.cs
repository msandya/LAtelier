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

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        public string Phone { get; set; }

        public string Photo { get; set; }

        public byte[] Password { get; set; }

        public string GoogleRefreshToken { get; set; }

        public string FacebookAccessToken { get; set; }

        public string GoogleId { get; set; }

        public string FacebookId { get; set; }
    }
}
