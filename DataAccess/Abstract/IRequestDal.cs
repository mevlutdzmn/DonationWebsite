using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // veri tabanı işleri
    public interface IRequestDal:IEntityRepository<Request>
    {
        List<RequestDetailDto> GetRequestDetails();
        
        /*//kategoriye göre listeleme
        List<Request> GetAllCategory(int categoryId);*/
    }
}
