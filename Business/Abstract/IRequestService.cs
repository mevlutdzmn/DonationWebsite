using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRequestService
    {
        List<Request> GetAll();
        //kategori id sine  göre listele
        List<Request> GetByCategoryId(int id);
        List<Request> GetByCollectedAid(int collectedAid);
        List<RequestDetailDto> GetRequestDetails();
    }
}
