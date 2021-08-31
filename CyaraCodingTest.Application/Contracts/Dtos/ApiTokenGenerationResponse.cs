using System;
using System.Collections.Generic;
using System.Text;

namespace CyaraCodingTest.Application.Contracts.Dtos
{
    public class ApiTokenGenerationResponse
    {
        public DateTime ValidTo { get; set; }
        public string ApiToken { get; set; }
    }
}
