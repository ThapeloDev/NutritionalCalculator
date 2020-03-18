using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    class UsersRepositoryMock : IUsersRepository
    {
        public Users Add(Users entity)
        {
            return entity;
        }

        public void Delete(Users entity)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Users GetUserByEmail(string email)
        {
            Users response = null;
            if (email == "registered@email")
            {
                response = User("User Registered");
            }
            return response;
        }

        public Users GetUserById(string id)
        {
            Users response = null;
            if(id == "IdRegistered")
            {
                response = new Users()
                {
                    Id = id
                };
            }
            return response;
        }

        public Users GetUserByUserName(string userName)
        {
            Users response = null;
            if (userName == "RegisteredUser")
            {
                response = User(userName); 
                
            }
            return response;
        }

        private Users User(string userName)
        {
            return  new Users()
            {
                Id = "IdTest",
                UserName = userName,
                FirstName = "First name test",
                LastName = "Last name test",
                Email = "email@test",
                //Password hash for the word password
                PasswordHash = "cABhAHMAcwB3AG8AcgBkAA=="
            };
        }

        public void update(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
