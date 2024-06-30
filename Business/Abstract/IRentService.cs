using Entity.Concrete;
using Entity.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentService:IGenericService<Rent>
    {
        List<RentDto> GetRentalInfo();
    }
}
