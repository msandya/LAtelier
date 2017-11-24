using ITI.KDO.DAL;
using ITI.KDO.WebApp.Authentification;
using ITI.KDO.WebApp.Models.PresentViewModels;
using ITI.KDO.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.KDO.WebApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class PresentController : Controller
    {
        readonly PresentServices _presentService;

        public PresentController(PresentServices presentService)
        {
            _presentService = presentService;
        }

        [HttpGet("{userId}/getPresentByUserId")]
        public IActionResult GetPresentList(int userId)
        {
            Result<IEnumerable<Present>> result = _presentService.GetAllByUserId(userId);
            return this.CreateResult<IEnumerable<Present>, IEnumerable<PresentViewModel>>(result, o =>
            {
                o.ToViewModel = x => x.Select(s => s.ToPresentViewModel());
            });
        }

        [HttpGet("{presentId}", Name = "GetPresent")]
        public IActionResult GetPresentById(int presentId)
        {
            Result<Present> result = _presentService.GetById(presentId);
            return this.CreateResult<Present, PresentViewModel>(result, o =>
            {
                o.ToViewModel = s => s.ToPresentViewModel();
            });
        }

        [HttpPost]
        public IActionResult CreatePresent([FromBody] PresentViewModel model)
        {
            Result<Present> result = _presentService.CreatePresent(model.UserId, model.PresentName, model.LinkPresent, model.Price, model.CategoryPresentId);
            return this.CreateResult<Present, PresentViewModel>(result, o =>
            {
                o.ToViewModel = s => s.ToPresentViewModel();
                o.RouteName = "GetPresent";
                o.RouteValues = s => new { id = s.PresentId };
            });
        }

        [HttpPut("{presentId}")]
        public IActionResult UpdateStudent(int presentId, [FromBody] PresentViewModel model)
        {
            Result<Present> result = _presentService.UpdatePresent(model.PresentId, model.UserId, model.CategoryPresentId, model.Price, model.PresentName, model.LinkPresent);
            return this.CreateResult<Present, PresentViewModel>(result, o =>
            {
                o.ToViewModel = s => s.ToPresentViewModel();
            });
        }

        [HttpDelete("{presentId}")]
        public IActionResult DeleteStudent(int presentId)
        {
            Result<int> result = _presentService.Delete(presentId);
            return this.CreateResult(result);
        }
    }
}
