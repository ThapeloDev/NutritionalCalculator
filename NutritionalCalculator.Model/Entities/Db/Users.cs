using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public partial class Users
    {
        public Users()
        {
            ConsumedFoods = new HashSet<ConsumedFoods>();
            FoodsEditedByUsers = new HashSet<FoodsEditedByUsers>();
            UsersInRoles = new HashSet<UsersInRoles>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool? UnlockedAccount { get; set; }

        public virtual ICollection<ConsumedFoods> ConsumedFoods { get; set; }
        public virtual ICollection<FoodsEditedByUsers> FoodsEditedByUsers { get; set; }
        public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }
    }
}
