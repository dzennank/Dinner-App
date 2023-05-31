using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDuinner.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string TokenGenerator(Guid userId, string firstName, string lastName);
    }
}