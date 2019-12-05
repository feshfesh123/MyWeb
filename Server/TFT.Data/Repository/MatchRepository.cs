using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTB.Data.Context;
using TFTB.Data.Entities;

namespace TFTB.Data.Repository
{
    internal class MatchRepository : IMatchRepository
    {
        private readonly TFTDbContext dbContext;

        public MatchRepository(TFTDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Match>> GetAll()
        {
            return await dbContext.Matches.Include(x => x.Result).ToListAsync();
        }

        public async Task<Match> GetById(string id)
        {
            return await dbContext.Matches.Include(x => x.Result).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Join>> GetJoins(string id)
        {
            return await dbContext.Joins.Where(x => x.MatchId == id).Include(x => x.User).ToListAsync();
        }

        public async Task<List<Request>> GetRequests(string id)
        {
            return await dbContext.Requests.Where(x => x.MatchId == id).Include(x => x.User).ToListAsync();
        }

        public async Task<Result> GetResult(string id)
        {
            var match = await GetById(id);
            return match.Result;
        }

        public async Task<bool> SetResult(string id, Result result)
        {
            var match = await GetById(id);
            match.Result = result;
            match.IsFinish = true;
            dbContext.Matches.Update(match);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SetStart(string id)
        {
            var match = await GetById(id);
            match.IsStart = true;
            dbContext.Matches.Update(match);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
