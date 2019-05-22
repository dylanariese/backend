using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coffee.Data;
using Coffee.Domain;
using Coffee.Core.Users;
using Coffee.Domain.Dtos;

namespace Coffee.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService eventService;

        public EventsController(IEventsService service)
        {
            eventService = service;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        {
            return await eventService.GetEvents();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var coffeeEvent = await eventService.GetEvent(id);

            if (coffeeEvent == null)
            {
                return NotFound();
            }

            return coffeeEvent;
        }


        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(EventForCreationDto coffeeEvent)
        {
            var newEvent = await eventService.PostEvent(coffeeEvent);

            return CreatedAtAction("GetEvent", new { id = newEvent.EventId }, coffeeEvent);
        }

    }
}
