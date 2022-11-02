using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet-paket kullanımı
    public class EfRequestDal : EfEntityRepositoryBase<Request, DonationWebsiteContext>, IRequestDal
    {
        public List<RequestDetailDto> GetRequestDetails()
        {
            using (DonationWebsiteContext context= new DonationWebsiteContext())
            {
                //jion işlemi yapıldı
                var result = from r in context.Requests
                             join c in context.Categories
                             on r.CategoryId equals c.CategoryId
                             select new RequestDetailDto
                             {
                                 RequestId = r.RequestId,
                                 CategoryName = c.CategoryName,
                                 ReasonRequest = r.ReasonRequest,
                                 Wallet = r.Wallet,
                                 CollectedAid = r.CollectedAid
                             };
                return result.ToList();
            }
        }
    }
}
