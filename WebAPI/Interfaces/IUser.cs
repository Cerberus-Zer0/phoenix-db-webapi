using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IUser
    {
        bool SaveChanges();

        void CreateUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}