using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyaraCodingTest.Application.Contracts;
using CyaraCodingTest.Application.Contracts.Dtos;

namespace CyaraCodingTest.Web.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<AuthenticationResponse> Login([FromBody] AuthenticateRequest request)
        {
            return await _accountService.Authenticate(request);
        }
    }
}
