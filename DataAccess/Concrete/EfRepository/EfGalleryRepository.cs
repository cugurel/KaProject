using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EfRepository
{
    public class EfGalleryRepository : IGalleryDal
    {
        Context c = new Context();
        public void Add(Gallery gallery)
        {
            c.Add(gallery);
            c.SaveChanges();
        }

        public void Delete(Gallery gallery)
        {
            c.Remove(gallery);
            c.SaveChanges();
        }

        public List<Gallery> GetAll()
        {
            return c.Galleries.ToList();
        }

        public Gallery GetById(int id) 
        {
            return c.Galleries.Find(id);
        }

        public void Update(Gallery gallery)
        {
            c.Update(gallery);
            c.SaveChanges();
        }
    }
}
