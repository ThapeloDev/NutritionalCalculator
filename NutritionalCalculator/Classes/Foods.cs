using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;
using NutritionalCalculator.Classes.StaticClasses;
using System;
using System.Collections.Generic;
using FoodsModel = NutritionalCalculator.Model.Entities.Db.Foods;

namespace NutritionalCalculator.Classes
{
    public class Foods : IFoods
    {
        private IUnitOfWork _unitOfWork;
        private FoodsResponse response;

        public Foods(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            response = new FoodsResponse()
            {
                IsValid = true,
                Foods = new List<FoodsModel>()
            };
        }

        public FoodsResponse GetAll()
        {
            response.Foods = _unitOfWork.Foods.GetAllEntities();
            return response;
        }

        public FoodsResponse GetById(string foodId)
        {
            SetResponse(_unitOfWork.Foods.GetById(foodId));
            return response;
        }

        public FoodsResponse GetByName(string name)
        {
            SetResponse(_unitOfWork.Foods.GetByName(name));
            return response;         
        }
        private void SetResponse(FoodsModel food)
        {                
            response.Foods.Add(food);     
        }

        public FoodsResponse Create(FoodsModel food, string userIdOfCreator)
        {           
            ValidateFoodForCreate(food);
            CreateFood(food, userIdOfCreator);
            return response;
        }
        private void ValidateFoodForCreate(FoodsModel food)
        {
            if (AreAllReferenceUnitsNull(food) || DoesUserExist(food.Name))
            {
                response.IsValid = false;
                response.StatusCode = 400;
            }
            else
                response.IsValid = true;
            // return ProcessValidationForCreate(validation);
        }
        private bool AreAllReferenceUnitsNull(FoodsModel food)
        {
            return MeasuresValidator.CheckIfTheyAreNull(food.ReferenceMassInGrams, food.ReferenceVolumeInMililiters, food.ReferenceUnits);
        }
        private bool DoesUserExist(string name)
        {
            return (_unitOfWork.Foods.GetByName(name) != null);
        }
        private void CreateFood(FoodsModel food, string userIdOfEditor)
        {
            if (response.IsValid)
            {
                food.Id = GetId();
                response.Foods.Add(_unitOfWork.Foods.Add(food));
                SaveChanges();
                SaveUserEditedFood(userIdOfEditor, true, false);
            }
        }

        private string GetId()
        {
            string id = Guid.NewGuid().ToString();
            while(_unitOfWork.Foods.GetById(id) != null) id = Guid.NewGuid().ToString();
            return id;
        }

        public FoodsResponse Update(FoodsModel editedFood, string userIdOfEditor)
        {
            FoodsModel uneditedFood = _unitOfWork.Foods.GetById(editedFood.Id);
            ValidateFoodForUpdate(uneditedFood);
            Update(editedFood, uneditedFood);
            SaveUserEditedFood(userIdOfEditor, false, true);
            return response;
        }

        private void ValidateFoodForUpdate(FoodsModel uneditedFood)
        {
            if(uneditedFood == null)
            {
                response.IsValid = false;
                response.StatusCode = 400;
            } else
            {
                response.IsValid = true;
            }
        }
        private void Update(FoodsModel editedFood, FoodsModel uneditedFood)
        {
            if (response.IsValid)
            {
                SetUpFood(editedFood, uneditedFood);
                _unitOfWork.Foods.update(response.Foods[0]);
                SaveChanges();
                response.StatusCode = 201;
            }         
        }
        private void SetUpFood(FoodsModel editedFood, FoodsModel uneditedFood)
        {
            uneditedFood.Name = editedFood.Name;
            uneditedFood.ReferenceMassInGrams = editedFood.ReferenceMassInGrams;
            uneditedFood.ReferenceVolumeInMililiters = editedFood.ReferenceVolumeInMililiters;
            uneditedFood.Macronutrients = editedFood.Macronutrients;
            uneditedFood.Minerals = editedFood.Minerals;
            uneditedFood.FattyAcidsAndCholesterol = editedFood.FattyAcidsAndCholesterol;
            uneditedFood.Vitamins = editedFood.Vitamins;
            response.Foods.Add(uneditedFood);
        }

        private void SaveUserEditedFood(string userId, bool creation, bool edition)
        {
            if (response.IsValid)
            {
                FoodsEditedByUsers foodEditedByUser = new FoodsEditedByUsers()
                {
                    UserId = userId,
                    FoodId = response.Foods[0].Id,
                    Creation = creation,
                    Edition = edition
                };
                _unitOfWork.FoodsEditedByUsers.Add(foodEditedByUser);
                SaveChanges();
            }
        }

        public FoodsResponse Delete(string id)
        {
            DeleteResult(_unitOfWork.Foods.GetById(id));
            return response;
        }
        private void DeleteResult(FoodsModel food)
        {
            if (food != null)
            {
                Delete(food);
                response.IsValid = true;
                response.StatusCode = 200;
            } 
            else
            {
                response.IsValid = false;
                response.StatusCode = 400;
            }  
        }
        private void Delete(FoodsModel food)
        {
            _unitOfWork.Foods.Delete(food);
            SaveChanges();
        }

        private void SaveChanges() => _unitOfWork.commit();
    }
} 