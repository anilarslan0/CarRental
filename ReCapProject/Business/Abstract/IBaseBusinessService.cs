using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBaseBusinessService<T>
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
       
    }
}
