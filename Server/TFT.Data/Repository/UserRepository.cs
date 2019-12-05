using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFTB.Data.Context;
using TFTB.Data.Entities;

namespace TFTB.Data.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly TFTDbContext dbContext;
        public UserRepository(TFTDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Create(User user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetById(string id)
        {
            return await dbContext.Users.FindAsync(id);
        }

        public async Task<bool> Update(User user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
