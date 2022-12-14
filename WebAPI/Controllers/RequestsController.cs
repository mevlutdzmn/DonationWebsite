using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //route istek yapılırken insanlar bize nasıl ulaşsın için yazıldı
    [Route("api/[controller]")]
    //bu class bir controllerdır kendini ona göre yapılandır diye yazıldı
    [ApiController]
    public class RequestsController : ControllerBase
    {
        //Loosely coupled--gevşek bağlılık
        IRequestService _requestService;

        public RequestsController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            Thread.Sleep(500);

            var result =_requestService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

           
        }

        [HttpPost("add")]
        public IActionResult Add(Request request)
        {
            var result = _requestService.Add(request);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int requestId)
        {
            var result = _requestService.Delete(requestId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Request request)
        {
            var result = _requestService.Update(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

            [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {


            var result = _requestService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {


            var result = _requestService.GetByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getrequestdetails")]
        public IActionResult GetRequestDetails(int categoryId)
        {
            var result = _requestService.GetRequestDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
