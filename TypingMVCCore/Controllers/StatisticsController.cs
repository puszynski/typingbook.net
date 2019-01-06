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

        public IActionResult SaveBookPageProgress(string input)
        {
            var fooo = input;
            // TODO save user progress in DB
            return Ok();
        }

        public IActionResult SaveStatisticProgress(int correctTyped, int wrongTyped)
        {
            // TODO save user stats in DB
            var model = new List<int> { correctTyped, wrongTyped };
            return PartialView("_StatisticContainer", model); ;
        }
    }
}