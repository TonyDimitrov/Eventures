using Data.Web;
using Eventures.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eventures.Web.Services.Interfaces
{
    public interface IOrderService
    {
        bool Create(EventuresDbContext dbContext, EventVM model, ClaimsPrincipal user);

        IEnumerable<OrderVM> All(EventuresDbContext dbContext);

    }
}
