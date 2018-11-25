using Data.Web;
using Eventures.Web.Services.Interfaces;
using Eventures.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    public class OrdersController : Controller
    {
        private EventuresDbContext dbContext;
        private IOrderService orderService;

        public OrdersController(EventuresDbContext dbContext, IOrderService orderService)
        {
            this.dbContext = dbContext;
            this.orderService = orderService;
        }

        [HttpPost]
        public IActionResult Create(EventVM model)
        {
            var isCreated = this.orderService.Create(this.dbContext, model, this.User);
            if (isCreated)
            {
                return this.Redirect("/events/userevents");
            }
            return this.View();
        }

        public IActionResult All()
        {
            var orders = this.orderService.All(this.dbContext);
            return this.View(orders);
        }
    }
}
