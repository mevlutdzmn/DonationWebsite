using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRequestService
    {
        //Idataresult hem mesaj ve sonuç dondursün hemde işlemi yapsin diye kullanıldı
        IDataResult<List<Request>> GetAll();
        //kategori id sine  göre listele
        IDataResult<List<Request>> GetByCategoryId(int id);
        IDataResult<List<Request>> GetByCollectedAid(int collectedAid);
        IDataResult<List<RequestDetailDto>> GetRequestDetails();
        IDataResult<Request> GetById(int requestId);
        IResult Add(Request request);
        IResult Update(Request request);
        IResult AddTransactionalTest(Request request);
    }
}
