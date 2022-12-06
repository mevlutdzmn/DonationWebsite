using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IUserOperationClaimsService _userOperationClaimsService;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<int> AddUser(User user)
        {
            _userDal.Add(user);
            //_userOperationClaimsService.Add(new UserOperationClaim() { UserId = user.Id, OperationClaimId = 2 });
            return new SuccessDataResult<int>(user.Id, Messages.UserAdded);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<List<User>> GetAll()
        {

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IResult Delete(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            _userDal.Delete(result);
            return new SuccessResult(Messages.UserDeleted);
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
        public IDataResult<User> GetByUserMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
        public IResult ChangeUserPassword(ChangeUserPassword changeUserPassword)
        {
            byte[] passwordHash, passwordSalt;
            var userToCheck = GetByUserMail(changeUserPassword.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(changeUserPassword.OldPassWord, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorResult(Messages.PasswordError);
            }
            HashingHelper.CreatePasswordHash(changeUserPassword.NewPassword, out passwordHash, out passwordSalt);
            userToCheck.Data.PasswordHash = passwordHash;
            userToCheck.Data.PasswordSalt = passwordSalt;
            _userDal.Update(userToCheck.Data);
            return new SuccessResult(Messages.passwordChanged);

        }
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }
       
        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }
        public IDataResult<int> Add(UserCreateDto userCreateDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userCreateDto.Password, out passwordHash, out passwordSalt);
            User userForCreate = MapToUser(userCreateDto, passwordHash, passwordSalt);
            _userDal.Add(userForCreate);
           // _userOperationClaimsService.Add(new UserOperationClaim() { Id = userCreateDto.Id, OperationClaimId = 2 });
            return new SuccessDataResult<int>(userForCreate.Id, Messages.UserAdded);
        }
        private User MapToUser(UserCreateDto userCreateDto, byte[] passwordHash, byte[] passwordSalt)
        {
            return new User
            {

                Id = userCreateDto.Id,
                FirstName = userCreateDto.FirstName,
                LastName = userCreateDto.LastName,
                Email = userCreateDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
            };
        }
    }
}