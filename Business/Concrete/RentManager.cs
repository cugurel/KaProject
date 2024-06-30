using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentManager : IRentService
    {
        IRentDal _rentDal;

        public RentManager(IRentDal rentDal)
        {
            _rentDal = rentDal;
        }

        public void Add(Rent t)
        {
            _rentDal.Add(t);
        }

        public void Delete(Rent t)
        {
            _rentDal.Delete(t);
        }

        public List<Rent> GetAll()
        {
            return _rentDal.GetAll();
        }

        public Rent GetById(int id)
        {
            return _rentDal.GetById(id);
        }

        public List<RentDto> GetRentalInfo()
        {
            return _rentDal.GetRentInfo();
        }

        public void Update(Rent t)
        {
            _rentDal.Update(t);
        }
    }
}
