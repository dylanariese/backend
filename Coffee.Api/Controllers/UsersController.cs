using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coffee.Data;
using Coffee.Domain;
using Coffee.Core;
using Coffee.Core.Users;

namespace Coffee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await usersService.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await usersService.GetUser(id);
            
            if(user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/byDeviceId/123123-123123-BSSAD
        [HttpGet("byDeviceId/{deviceId}")]
        public async Task<ActionResult<User>> GetUser(string deviceId)
        {
            var user = await usersService.GetUserByDeviceId(deviceId);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await usersService.PostUser(user);

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }
    }
}
