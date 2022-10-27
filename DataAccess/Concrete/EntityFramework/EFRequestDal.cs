using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet-paket kullanımı
    public class EFRequestDal : IRequestDal
    {
        public void Add(Request entity)
        {
            //IDisposable pattern implementation of c#
            using (DonationWebsiteContext context = new DonationWebsiteContext()) 
            {
                //addedEntity : eklenen varlık 
                //referansı yakala
                var addedEntity = context.Entry(entity);
                //eklenecek bir nesne olduğunu belirtiyor 
                addedEntity.State = EntityState.Added;
                //ekle
                context.SaveChanges();
            }
        }

        public void Delete(Request entity)
        {
            //IDisposable pattern implementation of c#
            using (DonationWebsiteContext context = new DonationWebsiteContext())
            {
                //addedEntity : eklenen varlık 
                //referansı yakala
                var deletedEntity = context.Entry(entity);
                //silinecek  bir nesne 
                deletedEntity.State = EntityState.Deleted;
                //sil
                context.SaveChanges();
            }
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
            //IDisposable pattern implementation of c#
            using (DonationWebsiteContext context = new DonationWebsiteContext())
            {
                //addedEntity : eklenen varlık 
                //referansı yakala
                var updatedEntity = context.Entry(entity);
                //güncelenek bir nesne 
                updatedEntity.State = EntityState.Modified;
                //güncelle
                context.SaveChanges();
            }
        }
    }
}
