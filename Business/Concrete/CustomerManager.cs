using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public List<CustomerDto> GetAllCustomersWithCityAndTown()
        {
            return _customerDal.GetAllCustomersWithCityAndTown();
        }

        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }
    }
}
