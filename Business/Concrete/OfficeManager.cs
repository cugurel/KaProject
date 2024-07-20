using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OfficeManager : IOfficeService
    {
        IOfficeDal _officeDal;

        public OfficeManager(IOfficeDal officeDal)
        {
            _officeDal = officeDal;
        }

        public void Add(Office t)
        {
            _officeDal.Add(t);  
        }

        public void Delete(Office t)
        {
            _officeDal.Delete(t);
        }

        public List<Office> GetAll()
        {
            return _officeDal.GetAll();
        }

        public Office GetById(int id)
        {
            return _officeDal.GetById(id);
        }

        public void Update(Office t)
        {
            _officeDal.Update(t);
        }
    }
}
