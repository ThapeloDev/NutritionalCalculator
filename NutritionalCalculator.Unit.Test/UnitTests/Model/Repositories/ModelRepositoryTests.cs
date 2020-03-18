using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Model.Repositories;
using NutritionalCalculator.Unit.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Unit.Test.Model.Repositories
{
    [TestClass]
    public class ModelRepositoryTests
    {
        [TestMethod]
        public void Test_method_Add()
        {
            DbContextMock dbContextMock = new DbContextMock("testAdd");
            ModelRepository<ModelTest> modelRepository = new ModelRepository<ModelTest>(dbContextMock as  IDbContext);
            ModelTest response = modelRepository.Add(Register());
            Assert.AreEqual(Register().Id, response.Id);
        }

        [TestMethod]
        public void Test_method_Get_all_entities_return_all_entities()
        {
            DbContext dbContextMock = new DbContextMock("TestGetAllEntities");
            var users = Users();
            dbContextMock.AddRange(users);
            dbContextMock.SaveChanges();
            ModelRepository<ModelTest> modelRepository = new ModelRepository<ModelTest>(dbContextMock as IDbContext);
            List<ModelTest> response = modelRepository.GetAllEntities();
            Assert.AreEqual(users.Count, response.Count);
        }

        private ModelTest Register()
        {
            return new ModelTest()
            {
                Id = "IdTest",
                Name = "RegisterTest"
            };
        }

        private List<ModelTest> Users()
        {
            List<ModelTest> users = new List<ModelTest>()
            {
                new ModelTest()
                {
                    Id = "IdTest",
                    Name = "UserTest"
                },
                new ModelTest()
                {
                    Id = "IdTest2",
                    Name = "UserTest2"
                }
            };
            return users;
        }

        private DbContextMock DbContextDeleteTest()
        {
            DbContextMock dbContext = new DbContextMock("DbContextDeleteTest");
            dbContext.Add(Register());
            dbContext.SaveChanges();
            return dbContext;
        }
    }
}
