using AspNetCoreExample6.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreExample6.Controllers
{
    public class HomeController : Controller
    {
        private IViewModelService viewModelService { get; set; }

        public HomeController(IViewModelService viewModelService)
        {
            this.viewModelService = viewModelService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Fish Tank Dashboard";
            return View(viewModelService.GetDashboardViewModel());
        }

        public IActionResult Feed(int foodAmount)
        {
            var model = viewModelService.GetDashboardViewModel();
            model.LastFed = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}. Amount: {foodAmount}";
            return View("Index", model);
        }
    }
}
