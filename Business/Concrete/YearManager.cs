using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EfRepository;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class YearManager : IYearService
    {
        IYearDal _yearDal;

        public YearManager(IYearDal yearDal)
        {
            _yearDal = yearDal;
        }

        public void Add(Year year)
        {
            _yearDal.Add(year);
        }

        public void Delete(Year year)
        {
            _yearDal.Delete(year);
        }

        public List<Year> GetAll()
        {
            return _yearDal.GetAll();   
        }

        public Year GetById(int id)
        {
            return _yearDal.GetById(id);
        }

        public void Update(Year year)
        {
            _yearDal.Update(year);
        }
    }
}
