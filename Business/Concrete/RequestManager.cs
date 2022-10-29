using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public List<Request> GetAll()
        {
            //iş kodları
            //yetkisi varmı?
            return _requestDal.GetAll();
        }

        public List<Request> GetByCategoryId(int id)
        {
            //gönderdiğim id eşit ise kategori id ye listele
            return _requestDal.GetAll(r => r.CategoryId == id);
        }

        public List<Request> GetByCollectedAid(double collectedAid)
        {
            return _requestDal.GetAll(r => r.CollectedAid == collectedAid);
        }
    }
}
