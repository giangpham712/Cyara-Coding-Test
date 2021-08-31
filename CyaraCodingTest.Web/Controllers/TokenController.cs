using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyaraCodingTest.Application.Contracts;
using CyaraCodingTest.Application.Contracts.Dtos;
using CyaraCodingTest.Core.Common;
using Microsoft.AspNetCore.Authorization;

namespace CyaraCodingTest.Web.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IApiTokenService _apiTokenService;

        public TokenController(IApiTokenService apiTokenService)
        {
            _apiTokenService = apiTokenService;
        }

        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task<PaginatedResult<ApiData>> List([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return await _apiTokenService.ListTokens(page, pageSize);
        }

        [HttpPost]
        [Authorize]
        [Route("generate")]
        public async Task<ApiTokenGenerationResponse> Generate([FromBody] GenerateApiTokenRequest request)
        {
            return await _apiTokenService.Generate(request);
        }

        [HttpPost]
        [Route("validate")]
        public async Task<ApiData> Validate([FromBody] ValidateApiTokenRequest request)
        {
            return await _apiTokenService.Validate(request);
        }
    }
}
