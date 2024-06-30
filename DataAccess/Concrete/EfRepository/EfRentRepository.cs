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
    public class EfRentRepository : EfGenericRepository<Rent>, IRentDal
    {
        Context context = new Context();
        public List<RentDto> GetRentInfo()
        {
            var result = (from r in context.Rents
                          join c in context.Cars on r.CarId equals c.Id
                          select new RentDto
                          {
                              Id = c.Id,
                              CarId = c.Id,
                              Brand = c.Brand,
                              Model = c.Model,
                              Name = r.Name,
                              Surname = r.Surname,
                              Phone = r.Phone,
                              EndDate = r.EndDate,
                              StartDate = r.StartDate
                          });

            return result.ToList();

        }
    }
}
