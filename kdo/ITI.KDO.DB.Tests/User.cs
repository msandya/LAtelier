using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.KDO.DB.Tests
{
    public class User
    {
        readonly string _firstName;
        readonly string _lastName;
        readonly string _email;
        readonly DateTime _birthdate;
        readonly string _phone;
        readonly string _photo;

        public User(string firstName, string lastName, string email, DateTime birthdate, string phone, string photo)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _birthdate = birthdate;
            _phone = phone;
            _photo = photo;
        }

        public string FirstName
        {
            get { return _firstName; }
        }
        public string LastName
        {
            get { return _lastName; }
        }
        public string Email
        {
            get { return _email; }
        }
        public DateTime Birthdate
        {
            get { return _birthdate; }
        }
        public string Phone
        {
            get { return _phone; }
        }
        public string Photo
        {
            get { return _photo; }
        }
    }
}
