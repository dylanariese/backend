
using System;
using System.Collections.Generic;

namespace Coffee.Domain
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public User Organizor { get; set; }
    }
}