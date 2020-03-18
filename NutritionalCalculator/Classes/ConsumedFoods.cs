using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Classes.StaticClasses;
using NutritionalCalculator.Model;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;
using ConsumedFoodsModel = NutritionalCalculator.Model.Entities.Db.ConsumedFoods;

namespace NutritionalCalculator.Classes
{
    public class ConsumedFoods : IConsumedFoods
    {
        private ConsumedFoodsResponse response;
        private IUnitOfWork _unitOfWork;

        public ConsumedFoods(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            response = new ConsumedFoodsResponse();
        }

        public ConsumedFoodsResponse GetByUser(string userId)
        {
            response.ConsumedFood = _unitOfWork.ConsumedFoods.GetByUser(userId);
            response.IsValid = true;
            return response;
        }

        public ConsumedFoodsResponse Create(ConsumedFoodsModel consumedFood)
        {           
            ValidateNewRegister(consumedFood);
            if (response.IsValid) 
                SaveConsumedFood(consumedFood);
            return response;
        }
        private void ValidateNewRegister(ConsumedFoodsModel consumedFood)
        {
            if (_unitOfWork.ConsumedFoods.GetById(consumedFood) != null || consumedFood == null || MeasuresValidator.CheckIfTheyAreNull(consumedFood.MassConsumedInGr, consumedFood.VolumeConsumedInMl, consumedFood.ConsumedUnits))
                throw new Exception("Invalid food");
            else response.IsValid = true;
        }

        private void SaveConsumedFood(ConsumedFoodsModel consumedFood)
        {
            _unitOfWork.ConsumedFoods.Add(consumedFood);
            _unitOfWork.commit();
        }

        public ConsumedFoodsResponse Update(ConsumedFoodsModel editedConsumedFood)
        {
            ConsumedFoodsModel uneditedConsumedFood = _unitOfWork.ConsumedFoods.GetById(editedConsumedFood);
            ValidateConsumedFood(editedConsumedFood, uneditedConsumedFood);
            if (response.IsValid)
            {
                uneditedConsumedFood = editedConsumedFood;
                _unitOfWork.ConsumedFoods.Delete(editedConsumedFood);
                SaveChanges(uneditedConsumedFood);
            }              
            return response;
        }
       
        private void SaveChanges(ConsumedFoodsModel consumedFood)
        {
            _unitOfWork.ConsumedFoods.update(consumedFood);
            _unitOfWork.commit();
            response.StatusCode = 200;
        }
      
        public ConsumedFoodsResponse Delete(ConsumedFoodsModel consumedFood)
        {
            ConsumedFoodsModel uneditedConsumedFood = _unitOfWork.ConsumedFoods.GetById(consumedFood);
            ValidateConsumedFood(consumedFood, uneditedConsumedFood);
            if (response.IsValid)
                DeleteRegister(uneditedConsumedFood);
            return response;
        }

        private void ValidateConsumedFood(ConsumedFoodsModel editedConsumedFood, ConsumedFoodsModel uneditedConsumedFood)
        {
            bool doesTheFoodAlreadyExist = (uneditedConsumedFood != null);
            bool areAllNullReferencesValues = MeasuresValidator.CheckIfTheyAreNull(editedConsumedFood.MassConsumedInGr, editedConsumedFood.VolumeConsumedInMl, editedConsumedFood.ConsumedUnits);
            if (!doesTheFoodAlreadyExist || areAllNullReferencesValues)
                throw new Exception("Invalid Food");
            else
                response.IsValid = true;
        }
        private void DeleteRegister(ConsumedFoodsModel consumedFood)
        {
            _unitOfWork.ConsumedFoods.Delete(consumedFood);
            _unitOfWork.commit();
            response.StatusCode = 200;
        }

    }
}
