using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //bağımlılığı minimize ederiz,constractor injection

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //iş kodları yazılacak
            return _categoryDal.GetAll();
        }
        //select * from Categories where categoryId=3
        public Category GetById(int categoryId)
        {

            return _categoryDal.Get(c =>c.CategoryId == categoryId);
        }
    }
}
