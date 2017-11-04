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

        public DateTime BirthDate { get; set; }

        public int Phone { get; set; }

        public byte[] Password { get; set; }

        public string GoogleRefreshToken { get; set; }

        public string FacebookRefreshToken { get; set; }

        public int GoogleId { get; set; }

        public int FacebookId { get; set; }
    }
}
