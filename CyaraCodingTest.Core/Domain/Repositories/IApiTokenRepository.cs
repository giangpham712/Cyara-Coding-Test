using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CyaraCodingTest.Core.Domain.Entities;

namespace CyaraCodingTest.Core.Domain.Repositories
{
    public interface IApiTokenRepository
    {
        Task<IEnumerable<ApiToken>> ListAsync(int page, int pageSize);
        Task<ApiToken> FindByTokenAsync(string token);
        Task<int> CountAsync();
        Task<ApiToken> AddAsync(ApiToken apiToken);
    }
}
