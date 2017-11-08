using ITI.KDO.DAL;
using ITI.KDO.WebApp.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ITI.KDO.WebApp.Services
{
    public class UserServices
    {
        readonly UserGateway _userGateway;
        readonly PasswordHasher _passwordHasher;

        public UserServices(UserGateway userGateway, PasswordHasher passwordHasher)
        {
            _userGateway = userGateway;
            _passwordHasher = passwordHasher;
        }

        public bool CreatePasswordUser(RegisterViewModel model)
        {
            if (_userGateway.FindByEmail(model.Email) != null) return false;
            _userGateway.CreatePasswordUser(model.Email, model.FirstName, model.LastName, model.Birthdate, model.Phone, _passwordHasher.HashPassword(model.Password), model.Photo);

            return true;
        }

        public User FindUserPasswordHashed(string email)
        {
            User user = _userGateway.FindByEmail(email);
            user.Password = _userGateway.FindUserPasswordHashed(user.UserId).Password;
            return user;
        }

        public User FindUser(string email, string password)
        {
            User user = _userGateway.FindByEmail(email);
            if (user != null)
            {
                user.Password = _userGateway.FindUserPasswordHashed(user.UserId).Password;
                if(_passwordHasher.VerifyHashedPassword(user.Password, password) == PasswordVerificationResult.Success)
                    return user;
            } 
            return null;
        }

        public User FindUser(string email)
        {
            return _userGateway.FindByEmail(email);
        }

        public User FindUserByEmail(string email) => _userGateway.FindByEmail(email);

        public User FindUserById(int userId) => _userGateway.FindById(userId);

        public Result<int> Delete(int userId)
        {
            if (_userGateway.FindById(userId) == null) return Result.Failure<int>(Status.BadRequest, "User not found.");
            _userGateway.Delete(userId);
            return Result.Success(Status.Ok, userId);
        }

        public Result<IEnumerable<User>> GetAll()
        {
            return Result.Success(Status.Ok, _userGateway.GetAll());
        }

        public Result<User> CreateUser(string firstName, string lastName, string email, DateTime birthdate, string phone, string photo)
        {
            if (!IsNameValid(firstName)) return Result.Failure<User>(Status.BadRequest, "The first name is invalid.");
            if (!IsNameValid(lastName)) return Result.Failure<User>(Status.BadRequest, "The last name is invalid.");
            if (!IsNameValid(email)) return Result.Failure<User>(Status.BadRequest, "The email is invalid.");
            if (!IsPhoneTelValid(phone)) return Result.Failure<User>(Status.BadRequest, "The phone number is invalid.");
            if (!IsPhotoValid(photo)) return Result.Failure<User>(Status.BadRequest, "The photo  is invalid.");


            _userGateway.Create(firstName, lastName, birthdate, email, phone, photo);
            User user = _userGateway.FindByEmail(email);
            return Result.Success(Status.Ok, user);
        }

        public Result<User> UpdateUser(int userId, string firstName, string lastName, string email, DateTime birthdate, string phone, string photo)
        {
            if (!IsNameValid(firstName)) return Result.Failure<User>(Status.BadRequest, "The first name is invalid.");
            if (!IsNameValid(lastName)) return Result.Failure<User>(Status.BadRequest, "The last name is invalid.");
            if (!IsNameValid(email)) return Result.Failure<User>(Status.BadRequest, "The email is invalid.");
            if (!IsPhoneTelValid(phone)) return Result.Failure<User>(Status.BadRequest, "The phone number is invalid.");
            if (!IsPhotoValid(photo)) return Result.Failure<User>(Status.BadRequest, "The photo is invalid.");

            _userGateway.Update(userId, firstName, lastName, birthdate, email, phone, photo);
            User user = _userGateway.FindById(userId);
            return Result.Success(Status.Ok, user);
        }

        public Result<User> UpdateUserPassword(int userId, string password)
        {
            _userGateway.UpdatePassword(userId, _passwordHasher.HashPassword(password));
            User user = _userGateway.FindById(userId);
            return Result.Success(Status.Ok, user);
        }

        bool IsNameValid(string nameString) => !string.IsNullOrEmpty(nameString);

        bool IsPhoneTelValid(string phoneTel) => !Regex.IsMatch(phoneTel, @"^[a-zA-Z]+$");

        bool IsPhotoValid(string photo) => !string.IsNullOrEmpty(photo);

        public bool CreateOrUpdateGoogleUser(string email, string googleId,string refreshToken)
        {
            User user = _userGateway.FindByEmail(email);
            if (user == null)
            {
                _userGateway.CreateGoogleUser(email, googleId, refreshToken);
                return true;
            }
            if (user.FacebookRefreshToken == string.Empty)
            {
                _userGateway.AddGoogleToken(user.UserId, user.GoogleId,refreshToken);
            }
            else
            {
                _userGateway.UpdateGoogleToken( user.UserId,user.GoogleId, refreshToken);
            }
            return false;
        }

    }
}
