﻿using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EfRepository
{
    public class EfCategoryRepository : ICategoryDal
    {
        Context c = new Context();
        public void Add(Category category)
        {
            c.Add(category);
            c.SaveChanges();

        }

        public void Delete(Category category)
        {
            c.Remove(category);
            c.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return c.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return c.Categories.Find(id);
        }

        public void Update(Category category)
        {
            c.Update(category);
            c.SaveChanges();
        }
    }
}