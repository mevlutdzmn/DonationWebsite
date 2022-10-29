using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //tek data getirmek için yazıldı
        public Request Get(Expression<Func<Request, bool>> filter)
        {
            using (DonationWebsiteContext context = new DonationWebsiteContext())
            {
                return context.Set<Request>().SingleOrDefault(filter);
            }
        }
        //expression filtre verebilir isterse vermeyedebiler null ile 
        public List<Request> GetAll(Expression<Func<Request, bool>> filter = null)
        {
            using (DonationWebsiteContext context = new DonationWebsiteContext())
            {
                //eğer filtre verilmemişse tüm veritabanını listele ama verilmişse : eğer filtre verilmişse filtereye göre listele
                return filter == null ? context.Set<Request>().ToList() : context.Set<Request>().Where(filter).ToList();
            }
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
