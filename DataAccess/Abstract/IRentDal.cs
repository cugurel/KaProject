using Entity.Concrete;
using Entity.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentDal:IGenericDal<Rent>
    {
        List<RentDto> GetRentInfo();
    }
}
