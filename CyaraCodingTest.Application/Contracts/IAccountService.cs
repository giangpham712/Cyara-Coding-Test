using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CyaraCodingTest.Application.Contracts.Dtos;

namespace CyaraCodingTest.Application.Contracts
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> Authenticate(AuthenticateRequest request);
    }
}
