using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService:IBaseBusinessService<Car>
    {
        IDataResult<Car> GetbyCarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetail();

        IDataResult<List<CarDetailDto>> GetAllByBrandId(int Id);

       IDataResult<List<Car>> GetAllByColorId(int Id);

        



    }
}
