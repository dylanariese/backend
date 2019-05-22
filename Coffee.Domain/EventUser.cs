
using System;
using System.Collections.Generic;

namespace Coffee.Domain
{
    public class EventUser
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}