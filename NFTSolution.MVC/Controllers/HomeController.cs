using Microsoft.AspNetCore.Mvc;
using NFTSolution.BL.Services;
using NFTSolution.DAL.Models;

namespace NFTSolution.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MarketService _marketServices;

        public HomeController()
        {
            _marketServices = new MarketService();
        }
        public IActionResult Index()
        {
           List<Market> markets = _marketServices.GetAllMarket();
            return View(markets);
        }
    }
}
