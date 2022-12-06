using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<int> AddUser(User user);
        IDataResult<int> Add(UserCreateDto userCreateDto);
        IResult Delete(int id);
        IResult Update(User user);
        ////IResult UpdateUserDto(UserUpdateDto userUpdateDto);
        IDataResult<List<UserDetailDto>> GetUserDetails();
        //IDataResult<UserDetailDto> GetUserDetailById(int Id);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int Id);
        IDataResult<User> GetByUserMail(string Email);
        //User GetByMail(string Email);
        //List<OperationClaim> GetClaims(User user);
        //IDataResult<List<OperationClaim>> GetClaimsByUserId(int Id);
        //IDataResult<UserDetailDto> GetUserDetailsByEmail(string email);
        IResult ChangeUserPassword(ChangeUserPassword changeUserPassword);
        List<OperationClaim> GetClaims(User user);
        //void Add(User user);
        User GetByMail(string email);

    }
}