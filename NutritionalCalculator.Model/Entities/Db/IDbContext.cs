using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public interface IDbContext
    {
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<ConsumedFoods> ConsumedFoods { get; set; }
        DbSet<FattyAcidsAndCholesterol> FattyAcidsAndCholesterol { get; set; }
        DbSet<FoodsCategories> FoodsCategories { get; set; }
        DbSet<FoodsInCategories> FoodsInCategories { get; set; }
        DbSet<FoodsReferences> FoodsReferences { get; set; }
        DbSet<Foods> Foods { get; set; }
        DbSet<FoodsEditedByUsers> FoodsEditedByUsers { get; set; }
        DbSet<Macronutrients> Macronutrients { get; set; }
        DbSet<Minerals> Minerals { get; set; }
        DbSet<Reference> Reference { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<UsersInRoles> UsersInRoles { get; set; }
        DbSet<Vitamins> Vitamins { get; set; }
    }
}
