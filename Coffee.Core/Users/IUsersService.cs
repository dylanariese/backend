using Coffee.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Core.Users
{
    public interface IUsersService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> GetUserByDeviceId(string id);
        Task<User> PostUser(User user);
    }
}
