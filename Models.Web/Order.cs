using System;

namespace Models.Web
{
    public class Order : BaseEntity<string>
    {
        public DateTime OrderedOn { get; set; }

        public int TicketsCount { get; set; }

        public string UserId { get; set; }

        public EventureUser User { get; set; }

        public string EventId { get; set; }

        public Event Event { get; set; }
    }
}
