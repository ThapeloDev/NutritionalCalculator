using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Models;

namespace NutritionalCalculator.Classes.Interfaces
{
    public interface IFoodsCategories
    {
        FoodsCategoriesResponse Create(EditedFoodCategory model);
        FoodsCategoriesResponse GetAllCategories();
        FoodsCategoriesResponse GetCategoryByName(string name);
    }
}
