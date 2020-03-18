using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public partial class Roles
    {
        public Roles()
        {
            UsersInRoles = new HashSet<UsersInRoles>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }
    }
}
