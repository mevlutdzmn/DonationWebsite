using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestImagesController : ControllerBase
    {
        IRequestImageService _requestImageService;

        public RequestImagesController(IRequestImageService requestImageService)
        {
            _requestImageService = requestImageService;
        }

        //[HttpGet("getall")]
        //public IActionResult GetAll()
        //{
        //    var result = _requestImageService.GetAll();
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}

        //[HttpGet("getbyid")]
        //public IActionResult GetById(int id)
        //{
        //    var result = _requestImageService.GetById(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpGet("getimagesbytrainerid")]
        //public IActionResult GetImagesByTrainerId(int trainerId)
        //{
        //    var result = _requestImageService.GetImagesByRequestId(trainerId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}


        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] RequestImage requestImage)
        {
            var result = _requestImageService.Add(file, requestImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpPost("delete")]
        //public IActionResult Delete([FromForm] IFormFile file, [FromForm] RequestImage requestImage)
        //{
        //    var result = _requestImageService.Delete(file, requestImage);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
        //[HttpPut("update")]
        //public IActionResult Update([FromForm] IFormFile file, [FromForm] RequestImage requestImage)
        //{
        //    var result = _requestImageService.Update(file, requestImage);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}