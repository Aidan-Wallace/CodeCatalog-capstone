using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IUserDao
    {
        UserModel GetUser(string username);
        List<UserModel> GetUsers();
        UserModel AddUser(string username, string password, string role);
    }
}
