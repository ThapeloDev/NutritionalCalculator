using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NutritionalCalculator.Model.Entities.Db;

namespace NutritionalCalculator.Model.Repositories
{
    public class UsersRepository : ModelRepository<Users>, IUsersRepository
    {
        public UsersRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public Users GetUserById(string id) => _dbSet.Find(id);

        public Users GetUserByUserName(string userName) => (from user in _context.Users
                                                            where user.UserName == userName
                                                            select user).FirstOrDefault();

        public Users GetUserByEmail(string Email) => (from user in _context.Users
                                                      where user.Email == Email
                                                      select user).FirstOrDefault();
    }
}
