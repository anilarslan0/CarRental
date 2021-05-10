using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : IBaseBusinessService<Rental>
    {
        IDataResult<Rental> GetByRentalId(int rentalId);
        IDataResult<List<RentCarDetailDto>> GetAllDetail();
        IDataResult<List<Rental>> GetListReturnDateIsNull();
    }
}
