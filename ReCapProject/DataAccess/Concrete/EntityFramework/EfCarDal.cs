using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntitiyRepositoryBase<Car, CarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarDbContext context=new CarDbContext())
            {
                var result = from c in context.Cars
                             join r in context.Colors
                             on
                             c.ColorId equals r.ColorId
                             join b in context.Brands
                             on
                             c.BrandId equals b.BrandId
                             select new CarDetailDto()
                             {
                                 CarId = c.CarId,
                                 CarName=c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = r.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetByBrandIdCarDetails(int brandId)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Cars
                             join r in context.Colors
                             on
                             c.ColorId equals r.ColorId
                             join b in context.Brands
                             on
                             c.BrandId equals b.BrandId
                             where c.BrandId==brandId
                             select new CarDetailDto()
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = r.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
