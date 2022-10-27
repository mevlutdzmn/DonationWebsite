using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRequestDal : IRequestDal
    {
        public void Add(Request entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Request entity)
        {
            throw new NotImplementedException();
        }

        public Request Get(Expression<Func<Request, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetAll(Expression<Func<Request, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Request entity)
        {
            throw new NotImplementedException();
        }
    }
}
