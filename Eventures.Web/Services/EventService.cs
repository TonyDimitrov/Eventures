using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Data.Web;
using Eventures.Web.Services.Interfaces;
using Eventures.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using Models.Web;

namespace Eventures.Web.Services
{
    public class EventsService : IEventsService
    {
        public IEnumerable<EventVM> All(EventuresDbContext dbContext)
        {
            return dbContext.Events.Select(e => new EventVM
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start,
                End = e.End
            });
        }

        public bool Create(EventuresDbContext dbContext, CreateEventVM model)
        {
            var dbEvent = new Event
            {
                Name = model.Name,
                Place = model.Place,
                Start = model.Start,
                End = model.End,
                PricePerTicket = model.PricePerTicket,
                TotalTickets = model.TotalTickets
            };
            dbContext.Events.Add(dbEvent);
            var changes = dbContext.SaveChanges();
            if (changes > 0)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<EventVM> UserEvents(EventuresDbContext dbContext, ClaimsPrincipal user)
        {
            //var orders = dbContext.EventureUsers
            //    .Where(u => u.UserName == user.Identity.Name).SelectMany(u => u.Orders.Select(o => new EventVM
            //    {
            //        Name = o.User.UserName,
            //        Start = o.Event.Start,
            //        End = o.Event.End,
            //        Tickets = o.TicketsCount
            //    })).ToList();


            var us = dbContext.Users.Include(u => u.Orders).ThenInclude(o => o.Event).FirstOrDefault(u => u.UserName == user.Identity.Name);
            List<EventVM> list = new List<EventVM>();
            foreach (var order in us.Orders)
            {
                if (order.Event == null)
                {
                    continue;
                }
                list.Add(new EventVM
                {
                    Name = order.Event.Name,
                    Start = order.Event.Start,
                    End = order.Event.End,
                    Tickets = order.TicketsCount
                });
            }
            return list;
        }
    }
}
