using Business.Concrete;
using CarProjectUI.Models;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.ViewComponents
{
    public class Statistic:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var startOfNextMonth = startOfMonth.AddMonths(1);

            StatisticInfo statistic = new StatisticInfo();

            statistic.CountOfRent= c.Rents.Count(r => r.StartDate >= startOfMonth && r.StartDate < startOfNextMonth);

            statistic.CountOfCar = c.Cars.Count();
            statistic.CountOfCategory = c.Categories.Count();
            statistic.CountOfComment = c.Comments.Count();
            return View(statistic);
        }
    }
}
