using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint(kısıt)
    //class : referans tip olabilir
    //IEntity: olabilir  veya implement eden bir nesne olabilir
    //new() : new'lenebilir olmalı 
    public interface IEntityRepository<T> where T:class ,IEntity,new()
    {
        //Expression--> filtreleme işlemleri yapmak için 
        
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

       
    }
}
