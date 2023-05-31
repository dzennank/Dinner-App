using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDuinner.Application.Common.Interfaces.Authentication.Services;

namespace BuberDinner.Infrastructure.Services
{
    public class DateProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}