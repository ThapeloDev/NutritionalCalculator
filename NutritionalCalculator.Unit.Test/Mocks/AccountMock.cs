using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    class AccountMock : Controller, IAccount
    {
        private bool _exception;
        public AccountMock(bool exception)
        {
            _exception = exception;
        }
        public AccountManagerResponse CreateUser(EditedUser model)
        {
            if (_exception)
                throw new Exception();
            AccountManagerResponse response = new AccountManagerResponse()
            {
                Token = new TokenModel()
            };
            if (model.Email == "email@nutritionalcalculator.com")
            {
                response.IsValid = true;
                response.Token.Value = "token";
            }
            else
            {
                response.IsValid = false;
                response.StatusCode = 400;
            }
            return response;
        }

        public AccountManagerResponse Login(LoginModel model)
        {
            if (_exception)
                throw new Exception();
            AccountManagerResponse response = new AccountManagerResponse();
            if (model.UserName == "UserNameTest") 
                response.IsValid = true;
            else
            {
                response.IsValid = false;
                response.StatusCode = 400;
            }                
            return response;
        }

        public bool CheckAvailability(string value)
        {
            if (_exception)
                throw new Exception();
            if (value != "InvalidUser")
                return true;
            else
                return false;
        }
    }
}
