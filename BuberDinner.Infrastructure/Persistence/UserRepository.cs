using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domen.Entities;
using BuberDuinner.Application.Common.Interfaces.Persistence;

namespace BuberDinner.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _user = new();
        public void Add(User user)
        {
            _user.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _user.SingleOrDefault(u => u.Email == email);
        }
    }
}