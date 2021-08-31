using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyaraCodingTest.Application.Contracts;
using CyaraCodingTest.Application.Contracts.Dtos;
using CyaraCodingTest.Application.Exceptions;
using CyaraCodingTest.Core.Common;
using CyaraCodingTest.Core.Domain.Entities;
using CyaraCodingTest.Core.Domain.Repositories;
using CyaraCodingTest.Core.Token;

namespace CyaraCodingTest.Application.Services
{
    public class ApiTokenService : IApiTokenService
    {
        private readonly IApiTokenRepository _apiTokenRepository;
        private readonly IApiTokenProvider _apiTokenProvider;

        public ApiTokenService(
            IApiTokenRepository apiTokenRepository, 
            IApiTokenProvider apiTokenProvider)
        {
            _apiTokenRepository = apiTokenRepository;
            _apiTokenProvider = apiTokenProvider;
        }

        public async Task<PaginatedResult<ApiData>> ListTokens(int page = 1, int pageSize = 10)
        {
            var tokens = await _apiTokenRepository.ListAsync(page, pageSize);
            var tokenCount = await _apiTokenRepository.CountAsync();

            return new PaginatedResult<ApiData>()
            {
                Items = tokens.Select(x => new ApiData()
                {
                    AppUrl = x.AppUrl,
                    ApiToken = x.Token,
                    IsActive = x.IsActive,
                    ValidTo = x.ValidTo
                }).ToList(),
                Total = tokenCount
            };
        }

        public async Task<ApiTokenGenerationResponse> Generate(GenerateApiTokenRequest request)
        {
            string token;
            bool tokenExists;

            do
            {
                token = _apiTokenProvider.Generate(6, 12);
                tokenExists = (await _apiTokenRepository.FindByTokenAsync(token)) != null;

            } while (tokenExists);

            var validTo = DateTime.Now.AddDays(7);
            var apiToken = new ApiToken()
            {
                Token = token,
                AppUrl = request.AppUrl,
                ValidTo = validTo,
                IsActive = true
            };

            await _apiTokenRepository.AddAsync(apiToken);

            return new ApiTokenGenerationResponse()
            {
                ApiToken = token,
                ValidTo = validTo
            };
        }

        public async Task<ApiData> Validate(ValidateApiTokenRequest request)
        {
            var token = await _apiTokenRepository.FindByTokenAsync(request.ApiToken);
            if (token == null)
            {
                throw new EntityNotFoundException("API token not found");
            }

            if (token.ValidTo < DateTime.Now)
            {
                throw new TokenValidationException("API token expired");
            }

            return new ApiData()
            {
                AppUrl = token.AppUrl,
                ApiToken = token.Token,
                ValidTo = token.ValidTo,
                IsActive = token.IsActive
            };
        }
    }
}
