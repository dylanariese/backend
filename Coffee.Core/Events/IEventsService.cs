using Coffee.Domain;
using Coffee.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Core.Users
{
    public interface IEventsService
    {
        Task<List<Event>> GetEvents();
        Task<Event> GetEvent(int id);
        Task<Event> PostEvent(EventForCreationDto eventModel);
    }
}
