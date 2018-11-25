
using Data.Web;
using Eventures.Web.Services.Interfaces;
using Eventures.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private EventuresDbContext dbContext;

        private IEventsService eventService;

        public EventsController(EventuresDbContext dbContext, IEventsService eventService)
        {
            this.dbContext = dbContext;
            this.eventService = eventService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateEventVM model)
        {
            if (ModelState.IsValid)
            {
                if (this.eventService.Create(this.dbContext, model))
                {
                    return this.RedirectToAction("AllEvents");
                }
            }
            return this.View(model);
        }
        [HttpGet]
        public IActionResult AllEvents()
        {
            var allEvents = this.eventService.All(this.dbContext);
            return this.View(allEvents);
        }
        [HttpGet]
        public IActionResult UserEvents()
        {
            var allEvents = this.eventService.UserEvents(this.dbContext, this.User);
            return this.View(allEvents);
        }
    }
}
