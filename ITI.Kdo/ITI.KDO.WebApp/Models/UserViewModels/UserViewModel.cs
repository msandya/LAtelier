using System;

namespace ITI.KDO.WebApp.Models.UserViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string Pseudo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneTel { get; set; }

        public byte[] Password { get; set; }
    }
}
