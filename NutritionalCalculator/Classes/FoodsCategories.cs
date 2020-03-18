using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;
using FoodsCategoriesModel = NutritionalCalculator.Model.Entities.Db.FoodsCategories;

namespace NutritionalCalculator.Classes
{
    public class FoodsCategories : IFoodsCategories
    {
        private IUnitOfWork _unitOfWork;
        private FoodsCategoriesResponse response;
        
        public FoodsCategories(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            response = new FoodsCategoriesResponse() {
                IsValid = true,
                FoodCategories = new List<FoodsCategoriesModel>()
            };
        }

        public FoodsCategoriesResponse Create(EditedFoodCategory model)
        {
            //TODO: Eliminar el true y cambiarlo por el metodo que verifica que el usuario si tenga los permisos para realizar esta acción
            if (true)
            {
                ValidateModel(model);
                Create(model.Name);
                return response;
            }else
            {
                throw new Exception();
            }
        }
        private void ValidateModel(EditedFoodCategory model)
        {
            if (SearchByName(model.Name) == null)
            {
                response.IsValid = true;              
            }
            else
            {
                response.IsValid = false;
                response.StatusCode = 400;
            }
        }
       
        private void Create(string name)
        {
            if (response.IsValid)
            {
                response.FoodCategories.Add(_unitOfWork.FoodCategories.Add(NewCategory(name)));
                _unitOfWork.commit();
            }
        }
        private FoodsCategoriesModel NewCategory(string name)
        {
            return new FoodsCategoriesModel() { Name = name };
        }

        public FoodsCategoriesResponse GetAllCategories()
        {
            response.FoodCategories = _unitOfWork.FoodCategories.GetAllEntities();
            return response;
        }

        public FoodsCategoriesResponse GetCategoryByName(string name)
        {
            response.FoodCategories.Add(SearchByName(name));
            return response;
        }
        private FoodsCategoriesModel SearchByName(string name)
        {
            return _unitOfWork.FoodCategories.GetFoodCategoryByName(name);
        }
    }
}
