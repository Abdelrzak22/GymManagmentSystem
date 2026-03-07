using GymManagmentBLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnalyticService _analyticService;

        public HomeController(IAnalyticService analyticService)
        {
            _analyticService = analyticService;
        }

        public IActionResult Index()
        {

            var Data = _analyticService.GetAnalyticData();
            return View(Data);
        }

      
    }
}
