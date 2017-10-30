using ITI.KDO.DAL;
using ITI.KDO.WebApp.Authentification;
using ITI.KDO.WebApp.Models.UserViewModels;
using ITI.KDO.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.KDO.WebApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class UserController : Controller
    {
        readonly UserServices _userServices;

        public UserController( UserServices userServices )
        {
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult GetUserList()
        {
            Result<IEnumerable<User>> result = _userServices.GetAll();
            return this.CreateResult<IEnumerable<User>, IEnumerable<UserViewModel>>(result, o =>
            {
                o.ToViewModel = x => x.Select(s => s.ToUserViewModel());
            });
        }

        [HttpGet("{emailUser}")]
        public User GetUserByEmail(string emailUser)
        {
            User user = _userServices.FindUserPasswordHashed(emailUser);
            return user;
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] UserViewModel model)
        {
            Result<User> result = _userServices.UpdateUser(userId, model.Pseudo, model.FirstName, model.LastName, model.Email, model.BirthDate, model.PhoneTel);
            return this.CreateResult<User, UserViewModel>(result, o =>
            {
                o.ToViewModel = s => s.ToUserViewModel();
            });
        }
    }
}
