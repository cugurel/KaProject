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
    public class GalleryManager : IGalleryService
    {
        IGalleryDal _galleryDal;

        public GalleryManager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }

        public void Add(Gallery gallery)
        {
            _galleryDal.Add(gallery);
        }

        public void Delete(Gallery gallery)
        {
            _galleryDal.Delete(gallery);
        }

        public List<Gallery> GetAll()
        {
            return _galleryDal.GetAll();
        }

        public Gallery GetById(int id)
        {
            return _galleryDal.GetById(id);
        }

        public void Update(Gallery gallery)
        {
            _galleryDal.Update(gallery);
        }
    }
}
