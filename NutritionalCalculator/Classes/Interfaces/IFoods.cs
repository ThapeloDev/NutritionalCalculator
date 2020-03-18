using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Models;
using FoodsModel = NutritionalCalculator.Model.Entities.Db.Foods;

namespace NutritionalCalculator.Classes.Interfaces
{
    public interface IFoods
    {
        FoodsResponse Create(FoodsModel food, string userIdOfCreator);
        FoodsResponse GetAll();
        FoodsResponse GetById(string foodId);
        FoodsResponse GetByName(string name);
        FoodsResponse Update(FoodsModel editedFood, string userIdOfEditor);
        FoodsResponse Delete(string id);
    }
}
