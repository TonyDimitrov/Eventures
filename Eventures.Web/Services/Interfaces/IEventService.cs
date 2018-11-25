using Data.Web;
using Eventures.Web.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;

namespace Eventures.Web.Services.Interfaces
{
    public interface IEventsService
    {
        bool Create(EventuresDbContext dbContext, CreateEventVM model);

        IEnumerable<EventVM> All(EventuresDbContext dbContext);

        IEnumerable<EventVM> UserEvents(EventuresDbContext dbContext, ClaimsPrincipal user);
    }
}
