using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CyaraCodingTest.Application.Contracts.Dtos;
using CyaraCodingTest.Core.Common;

namespace CyaraCodingTest.Application.Contracts
{
    public interface IApiTokenService
    {
        Task<PaginatedResult<ApiData>> ListTokens(int page = 1, int pageSize = 10);
        Task<ApiTokenGenerationResponse> Generate(GenerateApiTokenRequest request);
        Task<ApiData> Validate(ValidateApiTokenRequest request);
    }
}
