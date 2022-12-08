using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRequestImageService
    {
        IResult Add(IFormFile file, RequestImage requestImage);
        IResult Delete(IFormFile file, RequestImage requestImage);
        IResult Update(IFormFile file, RequestImage requestImage);
        IDataResult<List<RequestImage>> GetAll();
        IDataResult<RequestImage> GetById(int requestImgId);
        IDataResult<List<RequestImageDto>> GetImagesByRequestId(int requestId);
    }
}