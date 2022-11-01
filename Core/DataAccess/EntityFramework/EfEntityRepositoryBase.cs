using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //entity tip ve context tip ver
    //generic hale getirildi
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        //TEntity ve TContext kısıtla
        where TEntity : class,IEntity,new() 
        where TContext : DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
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

        public void Delete(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
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
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        //expression filtre verebilir isterse vermeyedebiler null ile 
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //eğer filtre verilmemişse tüm veritabanını listele ama verilmişse : eğer filtre verilmişse filtereye göre listele
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
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
