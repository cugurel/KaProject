using Entity.Concrete.Dtos;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGalleryService
    {
        void Add(Gallery gallery);
        void Delete(Gallery gallery);
        void Update(Gallery gallery);
        Gallery GetById(int id);
        List<Gallery> GetAll();
    }
}
