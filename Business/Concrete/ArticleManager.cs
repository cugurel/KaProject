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
    public class ArticleManager : IArticleService
    {
        IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void Add(Article t)
        {
            _articleDal.Add(t);
        }

        public void Delete(Article t)
        {
            _articleDal.Delete(t);
        }

        public List<Article> GetAll()
        {
            return _articleDal.GetAll();
        }

        public Article GetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public void Update(Article t)
        {
            _articleDal.Update(t);
        }
    }
}
