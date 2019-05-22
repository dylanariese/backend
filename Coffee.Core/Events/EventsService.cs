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
    public class EventsService : IEventsService
    {
        private readonly CoffeeContext _context;
        private readonly IUsersService usersService;

        public EventsService(CoffeeContext context, IUsersService usersService)
        {
            _context = context;
            this.usersService = usersService;
        }

        public async Task<Event> GetEvent(int id)
        {
            return await _context.Event.Include(e => e.User).FirstOrDefaultAsync(e => e.EventId == id);
        }

        public async Task<List<Event>> GetEvents()
        {
            return await _context.Event.Include(e => e.User).ToListAsync();
        }

        public async Task<Event> PostEvent(Domain.Dtos.EventForCreationDto eventModel)
        {
            var user = await usersService.GetUserByDeviceId(eventModel.DeviceId);

            var newEvent = new Event
            {
                StartDate = DateTime.Now.AddHours(1),
                UserId = user.UserId
            };

             _context.Event.Add(newEvent);

            await _context.SaveChangesAsync();

            return newEvent;
        }
    }
}


