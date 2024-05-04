using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class,new()
    {
        List<T> GetAll();
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        T GetById(int id);
    }
}
