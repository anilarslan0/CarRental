using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService:IBaseBusinessService<Customer>
    {
        IDataResult<Customer> GetByCustomerId(int customerId);
     
    }
}
