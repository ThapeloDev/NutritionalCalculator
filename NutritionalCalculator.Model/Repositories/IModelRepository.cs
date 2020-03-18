using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Repositories
{
    public interface IModelRepository<T> where T:class
    {
        T Add(T entity);
        void Delete(T entity);
        List<T> GetAllEntities();
        void update(T entity);
    }
}
