using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGalleryDal
    {
        List<Gallery> GetAll();
        void Add(Gallery gallery);
        void Delete(Gallery gallery);
        void Update(Gallery gallery);
        Gallery GetById(int id);
    }
}
