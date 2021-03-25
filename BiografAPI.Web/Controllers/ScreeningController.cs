using BiografAPI.Web.Data;
using BiografAPI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BiografAPI.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScreeningController : Controller
    {
        DatabaseProcedures db = new DatabaseProcedures();

        [HttpGet]
        public IActionResult ListAll()
        {
            return Json(db.GetScreeningList());
        }

        [HttpGet("screening")]
        public IActionResult List([FromBody]Screening screening)
        {
            return Json(db.GetScreening(screening.Id));
        }

        ////https://localhost:44366/Screening/ListDay/2021-03-25
        //[Route("[controller]/ListDay/{day?}")]
        //public IActionResult ListSpecificDay(DateTime? day)
        //{
        //    int dayINT = day.Value.Day;

        //    return Json(db.GetScreeningList().Where(x => x.ScreeningStart.Value.Day == dayINT).ToList());
        //}

        ////https://localhost:44366/Screening/ListWeek/12
        //[Route("[controller]/ListWeek/{weekNumber?}")]
        //public IActionResult ListSpecificWeek(int weekNumber)
        //{
        //    DateTime startOfWeek = FirstDateOfWeekISO8601(DateTime.Now.Year, weekNumber);
        //    DateTime endOfWeek = startOfWeek.AddDays(6);

        //    return Json(db.GetScreeningList().Where(x => x.ScreeningStart.Value.Date >= startOfWeek && x.ScreeningStart.Value.Date <= endOfWeek).ToList());
        //}

        [HttpPost("screening")]
        public IActionResult Insert([FromBody]Screening screening)
        {
            return Ok(db.CreateScreening(screening.Id, Convert.ToInt32(screening.MovieId), Convert.ToInt32(screening.AuditoriumId), screening.ScreeningStart));
        }

        [HttpPut("screening")]
        public IActionResult Update([FromBody]Screening screening, int id, int? newMovieIdValue, int? newAuditoriumIdValue, DateTime? screeningStart)
        {
            var t = db.UpdateScreening(id, newMovieIdValue, newAuditoriumIdValue, screeningStart);

            return View();
        }

        [HttpDelete("screening")]
        public IActionResult Delete([FromBody]Screening screening, int id)
        {
            var t = db.DeleteScreening(id);

            return View();
        }

        public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            return result.AddDays(-3);
        }
    }
}
