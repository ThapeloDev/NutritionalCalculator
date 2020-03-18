using NutritionalCalculator.Classes;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    class UserManagerMock : IUserManager
    {
        public UserResponse Create(EditedUser model)
        {
            UserResponse response = SetResponse(model);
            if (model.UserName != "UserNameTestValid")
            {
                response.IsValid = false;
                response.StatusCode = 400;
            }
            return response;
        }

        public Users GetByEmail(string email)
        {
            if(email == "registered@email")
            {
                return ValidUser();
            }
            return null;
        }

        public Users GetByUserName(string userName)
        {
            if(userName == "RegisteredUser")
            {
                return ValidUser();
            }          
            return null;
        }

        private Users ValidUser()
        {
            return new Users()
            {
                Id = "1234asd",
                UserName = "RegisteredUser",
                FirstName = "Test user",
                LastName = "Test user",
                Email = "registered@email",
                // Password hash de: Password
                PasswordHash = "cABhAHMAcwB3AG8AcgBkAA=="
            };
        }

        private UserResponse SetResponse(EditedUser model)
        {
            return new UserResponse()
            {
                User = SetUser(model),
                IsValid = true
            };
        }

        private Users SetUser(EditedUser model)
        {
            return new Users()
            {
                Id = "IdTest",
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PasswordHash = model.Password
            };
        }
    }
}
