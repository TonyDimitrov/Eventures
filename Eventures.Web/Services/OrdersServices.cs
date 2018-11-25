using Data.Web;
using Eventures.Web.Services.Interfaces;
using Eventures.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using Models.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eventures.Web.Services
{
    public class OrdersServices : IOrderService
    {
        public IEnumerable<OrderVM> All(EventuresDbContext dbContext)
        {
            return dbContext.Orders.Select(o => new OrderVM
            {
               Customer = o.User.UserName,
               Event = o.Event.Name,
               OrderedOn = o.OrderedOn
            });
        }

        public bool Create(EventuresDbContext dbContext, EventVM model, ClaimsPrincipal user)
        {
            var _event = dbContext.Events.FirstOrDefault(e => e.Id == model.Id);
            var dbUser = dbContext.EventureUsers.Include(u => u.Events).ThenInclude(e => e.Order).FirstOrDefault(u => u.UserName == user.Identity.Name);

            var userEvent = dbUser.Events.FirstOrDefault(e => e.Id == _event.Id);
            if (userEvent != null)
            {
                userEvent.Order.TicketsCount += model.Tickets;
            }
            else
            {
                _event.User = dbUser;
                _event.UserId = dbUser.Id;
                var order = new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    Event = _event,
                    EventId = _event.Id,
                    TicketsCount = model.Tickets,
                    User = dbUser,
                    UserId = dbUser.Id
                };
                dbContext.Orders.Add(order);
            }
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
