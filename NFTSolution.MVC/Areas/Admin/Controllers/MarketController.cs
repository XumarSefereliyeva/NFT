using Microsoft.AspNetCore.Mvc;
using NFTSolution.BL.Services;
using NFTSolution.BL.ViewModels;
using NFTSolution.DAL.Models;

namespace NFTSolution.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarketController : Controller
    {
        private readonly MarketService _marketservices;

        public MarketController(MarketService marketservice)
        {
            _marketservices = marketservice;
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
        public IActionResult Create(MarketVM marketVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Tapilmadii");
            }
            _marketservices.Create(marketVM);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Info(int id)
        {
           Market markets= _marketservices.GetMarketById(id);
            return View(markets);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Market market = _marketservices.GetMarketById(id);
            return View(market);
        }
        [HttpPost]
        public IActionResult Update(int id,UpdateMarketVM marketVM)
        {
            _marketservices.Update(id, marketVM);
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
