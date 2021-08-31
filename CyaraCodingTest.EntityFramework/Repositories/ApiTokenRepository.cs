using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyaraCodingTest.Core.Domain.Entities;
using CyaraCodingTest.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CyaraCodingTest.EntityFramework.Repositories
{
    public class ApiTokenRepository : IApiTokenRepository
    {
        private readonly ApplicationDbContext _context;

        public ApiTokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApiToken>> ListAsync(int page, int pageSize)
        {
            return await _context.Set<ApiToken>()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<ApiToken> FindByTokenAsync(string token)
        {
            return await _context.Set<ApiToken>().FirstOrDefaultAsync(x => x.Token == token);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<ApiToken>().CountAsync();
        }

        public async Task<ApiToken> AddAsync(ApiToken apiToken)
        {
            await _context.Set<ApiToken>().AddAsync(apiToken);
            await _context.SaveChangesAsync();
            return apiToken;
        }
    }
}
