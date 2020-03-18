using Microsoft.EntityFrameworkCore;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model
{
    public class UnitOfWork : IUnitOfWork
    {
        private INutritionalCalculatorContext _dbContext;

        public UnitOfWork(INutritionalCalculatorContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IUsersRepository _users;
        private IFoodCategoriesRepository _foodCategories;
        private IFoodsRepository _foods;
        private IFoodsEditedByUsersRepository _foodsEditedByUsers;
        private IConsumedFoodsRepository _consumedFoods;
        private IUsersInRolesRepository _usersInRoles;
        private IRolesRepository _Roles;

        public IUsersRepository Users => _users ?? (_users = new UsersRepository(_dbContext));
        public IFoodCategoriesRepository FoodCategories => _foodCategories ?? (_foodCategories = new FoodCategoriesRepository(_dbContext));
        public IFoodsRepository Foods => _foods ?? (_foods = new FoodsRepository(_dbContext));
        public IFoodsEditedByUsersRepository FoodsEditedByUsers => _foodsEditedByUsers ?? (_foodsEditedByUsers = new FoodsEditedByUsersRepository(_dbContext));
        public IConsumedFoodsRepository ConsumedFoods => _consumedFoods ?? (_consumedFoods = new ConsumedFoodsRepository(_dbContext));
        public IUsersInRolesRepository UsersInRoles => _usersInRoles ?? (_usersInRoles = new UsersInRolesRepository(_dbContext));
        public IRolesRepository Roles => _Roles ?? (_Roles = new RolesRepository(_dbContext));
        public void commit() => _dbContext.SaveChanges();
    }
}
