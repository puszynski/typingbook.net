using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TypingMVCCore.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReloadStatistic()
        {
            var model = new List<int> { 31, 23, 51, 54, 12 };
            return PartialView("_StatisticContainer", model);
        }
    }
}