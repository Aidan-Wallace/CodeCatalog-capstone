using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IUserDao
    {
        User GetUser(string username);
        List<User> GetUsers();
        User AddUser(string username, string password, string role);

        //ReturnUser UpdateUser(int id, ReturnUser user);
    }
}
