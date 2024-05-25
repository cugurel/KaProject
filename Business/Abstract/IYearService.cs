using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IYearService
    {
        void Add(Year year);
        void Delete(Year year);
        void Update(Year year);
        Year GetById(int id);
        List<Year> GetAll();
    }
}
