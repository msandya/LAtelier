using ITI.KDO.DAL;
using ITI.KDO.WebApp.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.KDO.WebApp.Controllers
{
    public static class ModelExtensions
    {
        public static UserViewModel ToUserViewModel( this User @this )
        {
            return new UserViewModel
            {
                Email = @this.Email,
                FirstName = @this.FirstName,
                LastName = @this.LastName,
                Birthdate = @this.Birthdate,
                Phone = @this.Phone,                
                Photo = @this.Photo
            };
        }
    }
}
