using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public partial class UsersInRoles
    {
        public string UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
