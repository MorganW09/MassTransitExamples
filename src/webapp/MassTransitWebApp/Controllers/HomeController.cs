using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MassTransitWebApp.Models;
using MassTransit;

namespace MassTransitWebApp.Controllers
{
    public class HomeController : Controller
    {
        readonly IBusControl bus;

        public HomeController(IBusControl bus)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<ActionResult> Index(Person person)
        {
            await bus.Publish(person);
            return View();
        }
    }
}
