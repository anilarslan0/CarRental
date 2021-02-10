
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint
    //class: referans tip
    //IEntity: T yerine ya IEntity ya da IEntitiyden implemente eden bir nesne olabilir demek.
    //new() : new'lenebilir olmalı. new koyarsak IEntity newlenemeyeceği için T yerine koyulamaz.
    public interface IEntityRepository<T> where T : class, IEntitiy, new()  //T yerine yazılabilecekleri kısıtlıyoruz.
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entitiy);
        void Delete(T entitiy);
        void Update(T entitiy);
    }
}
