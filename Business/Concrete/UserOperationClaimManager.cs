using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimsService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;


        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;

        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult();
        }


        public IResult AddRange(List<UserOperationClaim> userOperationClaims)
        {
            userOperationClaims.ForEach(claim =>
            {
                _userOperationClaimDal.Add(claim);

            });
            return new SuccessResult();
        }


    }
}