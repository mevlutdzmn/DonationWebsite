using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryRequestDal : IRequestDal
    {
        //veri tabanı görevi alıyor
        List<Request> _request;
        public InMemoryRequestDal()
        {
            //uygulama çalıştığı anda listelesin
            _request = new List<Request> { 
                new Request{RequestId=1, CategoryId=1, ReasonRequest="sma hastası", Wallet="123jkadjkj12312", CollectedAid=123431},
                new Request{RequestId=2, CategoryId=1, ReasonRequest="x hastalığı", Wallet="12afaadjkj12312", CollectedAid=123131},
                new Request{RequestId=3, CategoryId=2, ReasonRequest="y hastası", Wallet="123jkrjkj12312", CollectedAid=123131},
                new Request{RequestId=4, CategoryId=2, ReasonRequest="z hastası", Wallet="123jkfhhfhfkj12312", CollectedAid=123131},
                new Request{RequestId=5, CategoryId=2, ReasonRequest="w hastası", Wallet="123jkahfthkj12312", CollectedAid=123131}
            };
        }
        public void Add(Request request) 
        {
            //gelen talepi veri tabanına eklen
            _request.Add(request); 
        }

        public void Delete(Request request)
        {
            //LINQ - Language Integrated Query
            //Lambda
            Request requestToDelete = null;
            requestToDelete = _request.SingleOrDefault(r => r.RequestId  == request.RequestId);

            _request.Remove(requestToDelete);
        }

        public Request Get(Expression<Func<Request, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetAll()
        {
            return _request;
        }

        public List<Request> GetAll(Expression<Func<Request, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetAllCategory(int categoryId)
        {
            return _request.Where(r => r.CategoryId == categoryId).ToList();
        }

        public List<RequestDetailDto> GetRequestDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Request request)
        {
            //gönderdiğim talep id'isine sahip listedeki talebi bul
           Request requestToUpdate = _request.SingleOrDefault(r => r.RequestId == request.RequestId);

            requestToUpdate.ReasonRequest = request.ReasonRequest;
        }
    }
}
