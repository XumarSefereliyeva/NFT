using Microsoft.AspNetCore.Mvc;
using NFTSolution.BL.Services;
using NFTSolution.DAL.Models;

namespace NFTSolution.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarketController : Controller
    {
        private readonly MarketService _marketservices;

        public MarketController()
        {
            _marketservices = new MarketService();
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Market> markets = _marketservices.GetAllMarket();
            return View(markets);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Market market)
        {
            _marketservices.Create(market);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Info(int id)
        {
            _marketservices.GetMarketById(id);
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Market market = _marketservices.GetMarketById(id);
            return View(market);
        }
        [HttpPost]
        public IActionResult Update(int id,Market market)
        {
            _marketservices.Update(id, market);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _marketservices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
