using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Constants;

namespace Business.Concrete
{
    public class RequestImageManager : IRequestImageService
    {
        IRequestImageDal _requestImageDal;
        IFileHelper _fileHelper;

        public RequestImageManager(IRequestImageDal requestImageDal, IFileHelper fileHelper)
        {
            _requestImageDal = requestImageDal;
            _fileHelper = fileHelper;
        }

        //[ValidationAspect(typeof(TrainerImageValidator))]
        public IResult Add(IFormFile file, RequestImage requestImage)
        {
            requestImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);

            _requestImageDal.Add(requestImage);
            return new SuccessResult(Messages.RequestImageAdded);
        }

        public IResult Delete(IFormFile file, RequestImage requestImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + requestImage.ImagePath);
            _requestImageDal.Delete(requestImage);
            return new SuccessResult(Messages.RequestImageDeleted);
        }

        
        public IDataResult<List<RequestImage>> GetAll()
        {

            return new SuccessDataResult<List<RequestImage>>(_requestImageDal.GetAll(), Messages.RequestImageListed);
        }

       
        public IDataResult<RequestImage> GetById(int requestImgId)
        {
            return new SuccessDataResult<RequestImage>(_requestImageDal.Get(r => r.Id == requestImgId));
        }

        public IDataResult<List<RequestImageDto>> GetImagesByRequestId(int requestId)
        {
            var result = _requestImageDal.GetRequestImageDetails(requestImage => requestImage.RequestId == requestId);
            foreach (var requestImage in result)
            {
                requestImage.ImagePath = _fileHelper.GetByName(PathConstants.ImagesPath + requestImage.ImagePath);
            }

            return new SuccessDataResult<List<RequestImageDto>>(result, Messages.succeed);
        }

        public IResult Update(IFormFile file, RequestImage requestImage)
        {
            var requestForUpdate = _requestImageDal.Get(image => image.RequestId == requestImage.RequestId);
            if (requestForUpdate == null)
            {
                return this.Add(file, requestImage);
            }

            requestForUpdate.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + requestImage.ImagePath, PathConstants.ImagesPath);
            _requestImageDal.Update(requestForUpdate);
            return new SuccessResult(Messages.RequestImageUpdated);
        }
    }
}