using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Model;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Model.Repositories;
using NutritionalCalculator.Unit.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutritionalCalculator.Unit.Test.Model
{
    [TestClass]
    public class UnitOfWorkTests
    {
        [TestMethod]
        public void Test_Add_user()
        {
            DbContext dbContext = new DbContextMock("TestAddUser");
            Users user = User();
            IUnitOfWork unitOfWork = new UnitOfWork(dbContext  as INutritionalCalculatorContext); 
            var response = unitOfWork.Users.Add(user);
            dbContext.SaveChanges();
            var response2 = dbContext.Find<Users>(response.UserName);
            Assert.AreEqual(response, dbContext.Find<Users>(response.Id));
        }
        [TestMethod]
        public void Test_Delete_Users()
        {
            DbContext dbContext = new DbContextMock("TestDelete");
            Users user = User();
            AddUser(user, dbContext);
            IUnitOfWork unitOfWork = new UnitOfWork(dbContext as INutritionalCalculatorContext);
            unitOfWork.Users.Delete(user);
            dbContext.SaveChanges();
            Assert.AreEqual(null, dbContext.Find<Users>(user.Id));
        }
        [TestMethod]
        public void Test_GetAllEntities()
        {
            DbContext dbContext = new DbContextMock("TestGetAllEntities");
            List <Users> users = Users();
            dbContext.AddRange(users);
            dbContext.SaveChanges();
            IUnitOfWork unitOfWork = new UnitOfWork(dbContext as INutritionalCalculatorContext);
            var response = unitOfWork.Users.GetAllEntities().Count();
            Assert.AreEqual(2, response);
        }
        [TestMethod]
        public void Test_Update()
        {
            DbContext dbContext = new DbContextMock("TestUpdate");
            Users user = User();
            dbContext.Add(user);
            dbContext.SaveChanges();
            IUnitOfWork unitOfWork = new UnitOfWork(dbContext as INutritionalCalculatorContext);
            user.FirstName = "First name test edited";
            unitOfWork.Users.update(user);
            dbContext.SaveChanges();
            Assert.AreEqual(dbContext.Find<Users>(user.Id).FirstName, user.FirstName);
        }

        private Users User()
        {
            return new Users()
            {
                Id = "IdTest",
                UserName = "UserNameTest",
                FirstName = "First name test",
                LastName = "Last name test",
                Email = "email@test",
                PasswordHash = "passwordTest"
            };
        }
        private List<Users> Users()
        {
            return new List<Users>()
            {
                new Users()
               {
                   Id = "IdTest",
                    UserName = "UserNameTest",
                    FirstName = "First name test",
                    LastName = "Last name test",
                    Email = "email@test",
                    PasswordHash = "passwordTest"
               },
               new Users()
               {
                  Id = "IdTest2",
                  UserName = "UserNameTest2",
                  FirstName = "First name test2",
                  LastName = "Last name test2",
                  Email = "email@test2",
                  PasswordHash = "passwordTest2"
               }
            };
        }
        private void AddUser(Users user, DbContext dbContext)
        {
            dbContext.Add(user);
            dbContext.SaveChanges();
        }
    }
}