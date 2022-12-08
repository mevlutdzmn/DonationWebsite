using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRequestImageDal : EfEntityRepositoryBase<RequestImage, DonationWebsiteContext>, IRequestImageDal
    {
        public List<RequestImageDto> GetRequestImageDetails(Expression<Func<RequestImage, bool>> filter = null)
        {

            using (DonationWebsiteContext context = new DonationWebsiteContext())
            {
                var result = from image in filter == null ? context.RequestImages : context.RequestImages.Where(filter)
                             join r in context.Requests
                             on image.RequestId equals r.RequestId
                             select new RequestImageDto
                             {
                                 Id = image.Id,
                                 RequestId = r.RequestId,
                                 ImagePath = image.ImagePath,

                             };
                return result.ToList();
            }
        }
    }
}