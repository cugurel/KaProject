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
    public class EfCustomerRepository : EfGenericRepository<Customer>, ICustomerDal
    {
        Context context = new Context();
        public List<CustomerDto> GetAllCustomersWithCityAndTown()
        {
            var result = (from c in context.Customers
                          join ct in context.Cities on c.CityId equals ct.Id
                          join y in context.Towns on c.TownId equals y.Id
                          select new CustomerDto
                          {
                              Id = c.Id,
                              Name = c.Name,
                              Surname = c.Surname,
                              BirthDate = c.BirthDate,
                              BirthPlace = c.BirthPlace,
                              CityName = ct.Name,
                              TownName = y.Name,
                              Gender = c.Gender,
                              FileUrl = c.FileUrl
                          });

            return result.ToList();
        }
    }
}
