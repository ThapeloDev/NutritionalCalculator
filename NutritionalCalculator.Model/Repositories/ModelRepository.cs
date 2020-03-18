using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NutritionalCalculator.Model.Entities.Db;

namespace NutritionalCalculator.Model.Repositories
{
    public class ModelRepository<T> : IModelRepository<T> where T : class
    {
        protected IDbContext _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }
        public ModelRepository(IDbContext context)
        {
            _context = context ?? throw new ArgumentNullException("Repository null");
            _dbSet = _context.Set<T>();
        }

        public T Add(T entity) => _dbSet.Add(entity).Entity;

        public void Delete(T entity) => _context.Entry(entity).State = EntityState.Deleted;

        public List<T> GetAllEntities() => _context.Set<T>().ToList();

        public void update(T entity) => _context.Entry(entity).State = EntityState.Modified;
    }
}
