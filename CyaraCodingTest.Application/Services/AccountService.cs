using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CyaraCodingTest.Application.Contracts;
using CyaraCodingTest.Application.Contracts.Dtos;
using CyaraCodingTest.Application.Exceptions;
using CyaraCodingTest.Core.Domain;
using CyaraCodingTest.Core.Token;
using Microsoft.AspNetCore.Identity;

namespace CyaraCodingTest.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccessTokenProvider _accessTokenProvider;

        public AccountService(UserManager<ApplicationUser> userManager, IAccessTokenProvider accessTokenProvider)
        {
            _userManager = userManager;
            _accessTokenProvider = accessTokenProvider;
        }

        public async Task<AuthenticationResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                throw new AuthenticationException("Invalid username and password combination.");
            }

            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!result)
            {
                throw new AuthenticationException("Invalid username and password combination.");
            }

            var token = _accessTokenProvider.GenerateToken(user.UserName);
            return new AuthenticationResponse()
            {
                AccessToken = token
            };
        }
    }
}
