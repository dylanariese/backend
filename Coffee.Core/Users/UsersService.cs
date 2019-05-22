using Coffee.Core.Users;
using Coffee.Data;
using Coffee.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Coffee.Core
{
    public class UsersService : IUsersService
    {
        private readonly CoffeeContext _context;

        public UsersService(CoffeeContext context)
        {
            _context = context;
        }
        public async Task<User> GetUser(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<User> GetUserByDeviceId(string deviceId)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.DeviceId == deviceId);
        }

        public async Task<List<User>> GetUsers()
        {
            return  await _context.User.ToListAsync();
        }

        public async Task<User> PostUser(User user)
        {
            _context.User.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

    }
}


