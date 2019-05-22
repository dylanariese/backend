
using System;

namespace Coffee.Domain
{
    public class Event
    {
        public int EventId { get; set; }

        public DateTime StartDate { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}