using ITI.KDO.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.KDO.WebApp.Services
{
    public class PresentServices
    {
        readonly PresentGateway _presentGateway;

        public PresentServices(PresentGateway presentGateway)
        {
            _presentGateway = presentGateway;
        }

        public Result<IEnumerable<Present>> GetAllByUserId(int userId)
        {
            return Result.Success(Status.Ok, _presentGateway.GetAllByUserId(userId));
        }

        public Result<Present> GetById(int id)
        {
            Present present;
            if ((present = _presentGateway.FindById(id)) == null) return Result.Failure<Present>(Status.NotFound, "Present not found.");
            return Result.Success(Status.Ok, present);
        }

        public Result<int> Delete(int presentId)
        {
            if (_presentGateway.FindById(presentId) == null) return Result.Failure<int>(Status.NotFound, "Present not found.");
            _presentGateway.Delete(presentId);
            return Result.Success(Status.Ok, presentId);
        }

        public Result<Present> UpdatePresent(int presentId, int userId, int categoryPresent, float price, string presentName, string linkPresent)
        {
            if (!IsNameValid(presentName)) return Result.Failure<Present>(Status.BadRequest, "The present's name is not valid.");
            if (!IsPriceValid(price)) return Result.Failure<Present>(Status.BadRequest, "The present's price is not valid.");
            Present present;
            if((present = _presentGateway.FindById(presentId)) == null)
            {
                return Result.Failure<Present>(Status.NotFound, "Present not found.");
            }

            {
                Present p = _presentGateway.FindByName(presentName);
                if(p != null && p.PresentId == presentId) return Result.Failure<Present>(Status.BadRequest, "A present with this name already exists.");
            }
            _presentGateway.Update(presentId, presentName, price, linkPresent, categoryPresent, userId);
            present = _presentGateway.FindByPresentId(presentId);
            return Result.Success(Status.Ok, present);
        }

        public Result<Present> CreatePresent(int userId, string presentName, string linkPresent, float price, int categoryPresent)
        {
            if (!IsNameValid(presentName)) return Result.Failure<Present>(Status.BadRequest, "The present's name is not valid.");
            if (!IsPriceValid(price)) return Result.Failure<Present>(Status.BadRequest, "The present's price is not valid.");
            _presentGateway.Create(presentName, price, linkPresent, categoryPresent, userId);
            Present present = _presentGateway.FindByName(presentName);
            return Result.Success(Status.Ok, present);
        }

        bool IsNameValid(string name) => !string.IsNullOrWhiteSpace(name);

        bool IsPriceValid(float price)
        {
            if (price <= 0) return false;
            return true;
        }
    }
}
