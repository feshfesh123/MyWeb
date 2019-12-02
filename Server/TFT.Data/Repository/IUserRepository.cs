using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFTB.Data.Entities;

namespace TFTB.Data.Repository
{
    interface IUserRepository
    {
        Task<User> GetById(string id);
        Task<bool> Update(User user);
    }
}
