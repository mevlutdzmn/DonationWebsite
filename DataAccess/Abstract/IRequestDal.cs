using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // veri tabanı işleri
    public interface IRequestDal:IEntityRepository<Request>
    {

        
        /*//kategoriye göre listeleme
        List<Request> GetAllCategory(int categoryId);*/
    }
}
