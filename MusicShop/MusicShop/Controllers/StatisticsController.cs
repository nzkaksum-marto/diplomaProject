using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MusicShop.Core.Contracts;
using MusicShop.Core.Services;
using MusicShop.Models.Statistics;

namespace MusicShop.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;
        public StatisticsController(IStatisticsService statisticsService)
        {
            this._statisticsService = statisticsService;
        }

        // GET: StatisticsController
        public ActionResult Index()
        {
           StatisticsVM statistics = new StatisticsVM();
            statistics.CountClients = _statisticsService.CountClients();
            statistics.CountProducts = _statisticsService.CountProducts();
            statistics.CountOrders = _statisticsService.CountOrders();
            statistics.SumOrders = _statisticsService.SumOrders();
           
            return View(statistics);
        }

        // GET: StatisticsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StatisticsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatisticsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatisticsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StatisticsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatisticsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StatisticsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
