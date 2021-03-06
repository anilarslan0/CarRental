﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetByBrandIdCarDetails(int brandId);

        CarDetailDto GetDetails(int carId);

        List<CarDetailDto> GetByColorIdCarDetails(int colorId);
    }
}
