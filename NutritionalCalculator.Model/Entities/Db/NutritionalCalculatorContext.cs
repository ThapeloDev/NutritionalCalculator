using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public class NutritionalCalculatorContext : DbContext, INutritionalCalculatorContext
    {
        public NutritionalCalculatorContext(DbContextOptions<NutritionalCalculatorContext> options)
            :base(options)
        {

        }

        public virtual DbSet<ConsumedFoods> ConsumedFoods { get; set; }
        public virtual DbSet<FattyAcidsAndCholesterol> FattyAcidsAndCholesterol { get; set; }
        public virtual DbSet<FoodsCategories> FoodsCategories { get; set; }
        public virtual DbSet<FoodsInCategories> FoodsInCategories { get; set; }
        public virtual DbSet<FoodsReferences> FoodsReferences { get; set; }
        public virtual DbSet<Foods> Foods { get; set; }
        public virtual DbSet<FoodsEditedByUsers> FoodsEditedByUsers { get; set; }
        public virtual DbSet<Macronutrients> Macronutrients { get; set; }
        public virtual DbSet<Minerals> Minerals { get; set; }
        public virtual DbSet<Reference> Reference { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersInRoles> UsersInRoles { get; set; }
        public virtual DbSet<Vitamins> Vitamins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");
            modelBuilder.Entity<ConsumedFoods>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.Date, e.NumberOfPlate, e.IdFood });

                entity.ToTable("ConsumedFoods", "Api");

                entity.Property(e => e.IdUser).HasMaxLength(150);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdFood).HasMaxLength(150);

                entity.HasOne(d => d.IdFoodNavigation)
                    .WithMany(p => p.ConsumedFoods)
                    .HasForeignKey(d => d.IdFood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsumedFoods__Foods");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.ConsumedFoods)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsumedFoods__Users");
            });

            modelBuilder.Entity<FattyAcidsAndCholesterol>(entity =>
            {
                entity.HasKey(e => e.IdFood);

                entity.ToTable("FattyAcidsAndCholesterol", "Api");

                entity.Property(e => e.IdFood)
                    .HasMaxLength(150)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdFoodNavigation)
                    .WithOne(p => p.FattyAcidsAndCholesterol)
                    .HasForeignKey<FattyAcidsAndCholesterol>(d => d.IdFood)
                    .HasConstraintName("FK_FattyAcidsAndCholesterol__Foods");
            });

            modelBuilder.Entity<FoodsCategories>(entity =>
            {
                entity.ToTable("FoodCategories", "Api");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<FoodsInCategories>(entity =>
            {
                entity.HasKey(e => new { e.FoodCategoryId, e.FoodId });

                entity.ToTable("FoodInCategories", "Api");

                entity.Property(e => e.FoodId).HasMaxLength(150);

                entity.HasOne(d => d.FoodCategory)
                    .WithMany(p => p.FoodInCategories)
                    .HasForeignKey(d => d.FoodCategoryId)
                    .HasConstraintName("FK_FoodInCategories___FoodCategory");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.FoodInCategories)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_FoodInCategories___Foods");
            });

            modelBuilder.Entity<FoodsReferences>(entity =>
            {
                entity.HasKey(e => new { e.IdFood, e.IdReference });

                entity.ToTable("FoodReferences", "Api");

                entity.Property(e => e.IdFood).HasMaxLength(150);

                entity.Property(e => e.IdReference).HasMaxLength(150);

                entity.HasOne(d => d.IdFoodNavigation)
                    .WithMany(p => p.FoodReferences)
                    .HasForeignKey(d => d.IdFood)
                    .HasConstraintName("FK_FoodReferences__Foods");

                entity.HasOne(d => d.IdReferenceNavigation)
                    .WithMany(p => p.FoodReferences)
                    .HasForeignKey(d => d.IdReference)
                    .HasConstraintName("FK_FoodReferences__References");
            });

            modelBuilder.Entity<Foods>(entity =>
            {
                entity.ToTable("Foods", "Api");

                entity.Property(e => e.Id)
                    .HasMaxLength(150)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<FoodsEditedByUsers>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FoodId, e.EditionDate });

                entity.ToTable("FoodsEditedByUsers", "Api");

                entity.Property(e => e.UserId).HasMaxLength(150);

                entity.Property(e => e.FoodId).HasMaxLength(150);

                entity.Property(e => e.EditionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.FoodsEditedByUsers)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_FoodsEditedByUsers__Foods");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FoodsEditedByUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_FoodsEditedByUsers__Users");
            });

            modelBuilder.Entity<Macronutrients>(entity =>
            {
                entity.HasKey(e => e.IdFood);

                entity.ToTable("Macronutrients", "Api");

                entity.Property(e => e.IdFood)
                    .HasMaxLength(150)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdFoodNavigation)
                    .WithOne(p => p.Macronutrients)
                    .HasForeignKey<Macronutrients>(d => d.IdFood)
                    .HasConstraintName("FK_Macronutrients__Foods");
            });

            modelBuilder.Entity<Minerals>(entity =>
            {
                entity.HasKey(e => e.IdFood);

                entity.ToTable("Minerals", "Api");

                entity.Property(e => e.IdFood)
                    .HasMaxLength(150)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdFoodNavigation)
                    .WithOne(p => p.Minerals)
                    .HasForeignKey<Minerals>(d => d.IdFood)
                    .HasConstraintName("FK_Minerals__Foods");
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.ToTable("Reference", "Api");

                entity.Property(e => e.Id)
                    .HasMaxLength(150)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("Roles", "Api");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "Api");

                entity.Property(e => e.Id)
                    .HasMaxLength(150)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.UnlockedAccount)
                    .HasColumnName("Unlocked account")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<UsersInRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("UsersInRoles", "Api");

                entity.Property(e => e.UserId).HasMaxLength(150);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersInRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UsersInRoles__Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersInRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UsersInRoles__Users");
            });

            modelBuilder.Entity<Vitamins>(entity =>
            {
                entity.HasKey(e => e.IdFood);

                entity.ToTable("Vitamins", "Api");

                entity.Property(e => e.IdFood)
                    .HasMaxLength(150)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdFoodNavigation)
                    .WithOne(p => p.Vitamins)
                    .HasForeignKey<Vitamins>(d => d.IdFood)
                    .HasConstraintName("FK_Vitamins__Foods");
            });

        }
    }
}
