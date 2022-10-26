using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // veri tabanı işleri
    public interface IRequestDal
    {

        List<Request> GetAll();
        void Add(Request request);
        void Update(Request request);
        void Delete(Request request);

        List<Request> GetAllCategory(int categoryId);
    }
}
