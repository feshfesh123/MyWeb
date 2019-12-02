using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFTB.Data.Entities;

namespace TFTB.Data.Repository
{
    interface IMatchRepository
    {
        Task<List<Join>> GetJoins(string id);
        Task<List<Request>> GetRequests(string id);
        Task<Result> GetResult(string id);
        Task<bool> SetStart(string id);
        Task<bool> SetResult(string id, Result result);
        Task<List<Match>> GetAll();
        Task<Match> GetById(string id);
        
    }
}
