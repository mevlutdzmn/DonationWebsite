using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //add methodunu doğrula requestvalidatordaki kurallara göre

        [ValidationAspect(typeof(RequestValidator))]
        //[CacheRemoveAspect("IRequestService.Get")]
        [SecuredOperation("admin")]
        public IResult Add(Request request)
        {
            //iş kodları
            //magic strings yapıldı
            //ValidationTool.Validate(new RequestValidator(), request);

            //iş motoru kullanıldı core katmanından 
            IResult result = BusinessRules.Run(CheckifReasonRequestexists(request.ReasonRequest), CheckifRequestCountOfCategoryCorrect(request.CategoryId));
            //eğer kuralla uymuyorsa result döndür uyuyorsa işlemi yap
            if (result!=null)
            {
                return result;
            }
            _requestDal.Add(request);
            return new Result(true, Messages.RequestAdded);

        }

        [CacheAspect]// key, value
        public IDataResult<List<Request>> GetAll()
        {
            //iş kodları,yetkisi varmı? kodlar buraya yazılacak
            //belli bir saatten sonra talep listelenmesini kapatmak istiyoruz
            //if (DateTime.Now.Hour == 12)
            //{
            //    return new ErrorDataResult<List<Request>>(Messages.MaintenanceTime);
            //}

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

        [CacheAspect]
        public IDataResult<Request> GetById(int requestId)
        {
            return new SuccessDataResult<Request>(_requestDal.Get(r => r.RequestId == requestId));
        }

        public IDataResult<List<RequestDetailDto>> GetRequestDetails()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<RequestDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RequestDetailDto>>( _requestDal.GetRequestDetails());
        }

        [ValidationAspect(typeof(RequestValidator))]
        //Belekteki içinde Get olan tüm key leri iptal et
        //IRequsetService teki tüm getleri sil
        [CacheRemoveAspect("IRequestService.Get")]
        public IResult Update(Request request)
        {
            throw new NotImplementedException();
        }
        //bu kategorideki talep sayısı en fazla 10 tane olmalı 
        private IResult CheckifRequestCountOfCategoryCorrect(int categoryId)
        {
            //o kategorideki talepleri bul ve sayısını yaz
            //select count (*) from requests where categoryId sql karşılığı 
            var result = _requestDal.GetAll(r => r.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.RequestCountOfCategoryError);
            }
            return new SuccessResult();

        }
        private IResult CheckifReasonRequestexists(string  reasonRequest)
        {
            
            //any  yazdığımıza uyan kayıt varmı demek
            //aynı talep nedeninden varmı 
            var result = _requestDal.GetAll(r => r.ReasonRequest == reasonRequest).Any();
            if (result)
            {
                return new ErrorResult(Messages.ReasonRequestAlreadyExists);
            }
            return new SuccessResult();

        }

        public IResult AddTransactionalTest(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
