using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFTB.Data.Entities;

namespace TFTB.Data.Repository
{
    public interface IUserRepository
    {
        Task<User> GetById(string id);
        Task<bool> Update(User user);
        Task<bool> Create(User user);
    }
}
