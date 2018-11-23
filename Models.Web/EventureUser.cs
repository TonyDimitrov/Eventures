
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Models.Web
{
   public class EventureUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Ucn { get; set; }

        public IEnumerable<Order> Orders { get; set; } = new HashSet<Order>();

        public IEnumerable<Event> Events { get; set; } = new HashSet<Event>();
    }
}
