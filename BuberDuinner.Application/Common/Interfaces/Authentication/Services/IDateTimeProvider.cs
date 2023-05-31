using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDuinner.Application.Common.Interfaces.Authentication.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}