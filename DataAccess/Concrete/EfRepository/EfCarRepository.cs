using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EfRepository
{
    public class EfCarRepository : EfGenericRepository<Car>, ICarDal
    {
        Context context = new Context();

        
        public List<CarCategoryDto> GetAllCarsWithCategory()
        {
            var result = (from c in context.Cars
                          join ct in context.Categories on c.CategoryId equals ct.Id
                          join y in context.Years on c.Year equals y.Id 
                          select new CarCategoryDto
                          {
                              FileUrl = c.FileUrl,
                              Id = c.Id,
                              Announcement = c.Announcement,
                              AnnouncementDate = c.AnnouncementDate,
                              Brand = c.Brand,
                              Serial = c.Serial,
                              Model = c.Model,
                              Year = y.YearInfo,
                              Fuel = c.Fuel,
                              Gear = c.Gear,
                              Km = c.Km,
                              Price = c.Price,
                              CategoryId = c.CategoryId,
                              CategoryName = ct.Name
                          });

            return result.ToList();


        }
    }
}
