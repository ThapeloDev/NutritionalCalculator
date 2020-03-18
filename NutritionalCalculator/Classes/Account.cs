using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace NutritionalCalculator.Classes
{
    public class Account : Controller, IAccount
    {
        private readonly IUserManager _userManager;
        private readonly IToken _token;
        private AccountManagerResponse response;

        public Account(IUserManager userManager, IToken token)
        {
            _userManager = userManager;
            _token = token;
            response = new AccountManagerResponse() {
                User = new UserData()
            };
        }

        public AccountManagerResponse CreateUser(EditedUser model)
        {
            UserResponse creationResult = _userManager.Create(model);
            SetResponse(creationResult);
            ProcessResponse();
            return response;
        }
        private void SetResponse(UserResponse userResponse)
        {
            response.IsValid = userResponse.IsValid;
            response.StatusCode = userResponse.StatusCode;
            setUserResponse(userResponse.User);
        }

        public AccountManagerResponse Login(LoginModel model)
        {
            ValidateModelForLogin(model);
            ProcessResponse();
            return response;
        }

        private void ValidateModelForLogin(LoginModel model)
        {
            Users user = _userManager.GetByUserName(model.UserName);
            SetResponseForCorrectUser(user);
            SetResponseForIncorrectUser(user);
            SetResponseForIncorrectUserPassword(user, model.Password);
        }
        private void SetResponseForCorrectUser(Users user)
        {
            if (user != null)
            {
                response.IsValid = true;
                setUserResponse(user);
            }
        }

        private void setUserResponse(Users user)
        {
            if (response.IsValid)
            {
                response.User.Id = user.Id;
                response.User.UserName = user.UserName;
                response.User.FirstName = user.FirstName;
                response.User.LastName = user.LastName;
                response.User.Email = user.Email;
            }
        }
        private void SetResponseForIncorrectUser(Users user)
        {
            if (user == null)
            {
                response.IsValid = false;
                response.StatusCode = 400;
            }
        }
        private void SetResponseForIncorrectUserPassword(Users user, string password)
        {
            if (response.IsValid && PasswordHash.GetPassword(user.PasswordHash) != password)
            {
                response.IsValid = false;
                response.StatusCode = 400;
                response.User = null;
            }
        }

        private void ProcessResponse()
        {
            IActionResult result;
            if (response.IsValid)
            {             
                response.Token = _token.Get(response.User);
                result = Ok(response);
            }
        }

        public bool CheckAvailability(string value)
        {
            bool userNameExist = CheckUserAvailability(value);
            bool emailExists = CheckEmailAvailability(value);

            return (userNameExist || emailExists);

        }
        private bool CheckUserAvailability(string userName)
        {
            return (_userManager.GetByUserName(userName) != null);
        }
        private bool CheckEmailAvailability(string email)
        {
            return (_userManager.GetByEmail(email) != null);
        }

    }
}
