

using BuberDinner.Domen.Entities;

namespace BuberDuinner.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        void Add(User user);
    }
}