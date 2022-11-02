using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RequestManager : IRequestService
    {
        IRequestDal _requestDal;

        public RequestManager(IRequestDal requestDal)
        {
            _requestDal = requestDal;
        }

        public IResult Add(Request request)
        {
            //iş kodları
            //magic strings yapıldı
            if (request.ReasonRequest.Length<5)
            {
                return new ErrorResult(Messages.ReasonRequestInvalid);
            }

            _requestDal.Add(request);
            return new Result(true, Messages.RequestAdded);
        }

        public IDataResult<List<Request>> GetAll()
        {
            //iş kodları,yetkisi varmı? kodlar buraya yazılacak
            //belli bir saatten sonra talep listelenmesini kapatmak istiyoruz
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Request>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Request>>(_requestDal.GetAll(),Messages.RequestsListed);
        }

        public IDataResult<List<Request>> GetByCategoryId(int id)
        {
            //gönderdiğim id eşit ise kategori id ye listele
            return new SuccessDataResult<List<Request>>(_requestDal.GetAll(r => r.CategoryId == id));
        }

        public IDataResult<List<Request>> GetByCollectedAid(int collectedAid)
        {
            return new SuccessDataResult<List<Request>>(_requestDal.GetAll(r => r.CollectedAid == collectedAid));
        }

        public IDataResult<Request> GetById(int requestId)
        {
            return new SuccessDataResult<Request>(_requestDal.Get(r => r.RequestId == requestId));
        }

        public IDataResult<List<RequestDetailDto>> GetRequestDetails()
        {
            return new SuccessDataResult<List<RequestDetailDto>>( _requestDal.GetRequestDetails());
        }
    }
}
