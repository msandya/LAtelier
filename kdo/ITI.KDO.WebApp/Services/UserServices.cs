﻿using ITI.KDO.DAL;
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
            if (_userGateway.FindByMail(model.Mail) != null) return false;
            _userGateway.CreatePasswordUser(model.Mail, model.FirstName, model.LastName, model.Birthdate, model.Phone, _passwordHasher.HashPassword(model.Password), model.Photo);

            return true;
        }

        public User FindUserPasswordHashed(string mail)
        {
            User user = _userGateway.FindByMail(mail);
            user.Password = _userGateway.FindUserPasswordHashed(user.UserId).Password;
            return user;
        }

        public User FindUser(string mail, string password)
        {
            User user = _userGateway.FindByMail(mail);
            if (user != null)
            {
                user.Password = _userGateway.FindUserPasswordHashed(user.UserId).Password;
                if(_passwordHasher.VerifyHashedPassword(user.Password, password) == PasswordVerificationResult.Success)
                    return user;
            } 
            return null;
        }

        public User FindUserByMail(string mail) => _userGateway.FindByMail(mail);

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

        public Result<User> CreateUser(string firstName, string lastName, string mail, DateTime birthdate, string phone, string photo)
        {
            if (!IsNameValid(firstName)) return Result.Failure<User>(Status.BadRequest, "The first name is invalid.");
            if (!IsNameValid(lastName)) return Result.Failure<User>(Status.BadRequest, "The last name is invalid.");
            if (!IsNameValid(mail)) return Result.Failure<User>(Status.BadRequest, "The mail is invalid.");
            if (!IsPhoneTelValid(phone)) return Result.Failure<User>(Status.BadRequest, "The phone number is invalid.");
            if (!IsPhotoValid(photo)) return Result.Failure<User>(Status.BadRequest, "The photo  is invalid.");


            _userGateway.Create(firstName, lastName, mail, birthdate, phone, photo);
            User user = _userGateway.FindByMail(mail);
            return Result.Success(Status.Ok, user);
        }

        public Result<User> UpdateUser(int userId, string firstName, string lastName, string mail, DateTime birthdate, string phone, string photo)
        {
            if (!IsNameValid(firstName)) return Result.Failure<User>(Status.BadRequest, "The first name is invalid.");
            if (!IsNameValid(lastName)) return Result.Failure<User>(Status.BadRequest, "The last name is invalid.");
            if (!IsNameValid(mail)) return Result.Failure<User>(Status.BadRequest, "The mail is invalid.");
            if (!IsPhoneTelValid(phone)) return Result.Failure<User>(Status.BadRequest, "The phone number is invalid.");
            if (!IsPhotoValid(photo)) return Result.Failure<User>(Status.BadRequest, "The photo is invalid.");

            _userGateway.Update(userId, firstName, lastName, mail, birthdate, phone, photo);
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


    }
}