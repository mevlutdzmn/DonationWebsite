using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public IActionResult Add(UserCreateDto user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _userService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

         [HttpGet("getbyid")]
         public IActionResult GetById(int id)
         {
             var result = _userService.GetById(id);
             if (result.Success)
             {
                 return Ok(result);
             }
             return BadRequest(result);
         }

         [HttpGet("getuserdetails")]
         public IActionResult GetUserDetails(int Id)
         {
             var result = _userService.GetUserDetails();
             if (result.Success)
             {
                 return Ok(result);
             }

             return BadRequest(result);
         }
        
         [HttpPost("changeuserpassword")]
         public IActionResult ChangeUserPassword(ChangeUserPassword changeUserPassword)
         {
             var result = _userService.ChangeUserPassword(changeUserPassword);
             if (result.Success)
             {
                 return Ok(result);
             }

             return BadRequest(result);
         }
        
    }
}