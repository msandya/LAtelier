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
            _userGateway.CreatePasswordUser(model.Pseudo, model.Email, model.FirstName, model.LastName, model.BirthDate, model.PhoneTel, _passwordHasher.HashPassword(model.Password));

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
                if(_passwordHasher.VerifyHashedPassword(user.Password, password) == PasswordVerificationResult.Success)
                    return user;
            } 
            return null;
        }

        public User FindUserByPseudo(string pseudo) => _userGateway.FindByPseudo(pseudo);

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

        public Result<User> CreateUser(string pseudo, string firstName, string lastName, string email, DateTime birthDate, string phoneTel)
        {
            if (!IsNameValid(pseudo)) return Result.Failure<User>(Status.BadRequest, "The username is invalid.");
            if (!IsNameValid(firstName)) return Result.Failure<User>(Status.BadRequest, "The first name is invalid.");
            if (!IsNameValid(lastName)) return Result.Failure<User>(Status.BadRequest, "The last name is invalid.");
            if (!IsNameValid(email)) return Result.Failure<User>(Status.BadRequest, "The email is invalid.");
            if (!IsPhoneTelValid(phoneTel)) return Result.Failure<User>(Status.BadRequest, "The phone number is invalid.");

            _userGateway.Create(pseudo, firstName, lastName, email, birthDate, phoneTel);
            User user = _userGateway.FindByPseudo(pseudo);
            return Result.Success(Status.Ok, user);
        }

        public Result<User> UpdateUser(int userId, string pseudo, string firstName, string lastName, string email, DateTime birthDate, string phoneTel)
        {
            if (!IsNameValid(pseudo)) return Result.Failure<User>(Status.BadRequest, "The username is invalid.");
            if (!IsNameValid(firstName)) return Result.Failure<User>(Status.BadRequest, "The first name is invalid.");
            if (!IsNameValid(lastName)) return Result.Failure<User>(Status.BadRequest, "The last name is invalid.");
            if (!IsNameValid(email)) return Result.Failure<User>(Status.BadRequest, "The email is invalid.");
            if (!IsPhoneTelValid(phoneTel)) return Result.Failure<User>(Status.BadRequest, "The phone number is invalid.");

            _userGateway.Update(userId, pseudo, firstName, lastName, email, birthDate, phoneTel);
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
    }
}
