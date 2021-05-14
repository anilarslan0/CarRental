using Business.Abstract;
using Business.BusinnesAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcern.Caching.Microsoft;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();

        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllByBrandId(int Id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetByBrandIdCarDetails(Id));
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllByColorId(int Id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetByColorIdCarDetails(Id));
        }
        [CacheAspect]
        public IDataResult<Car> GetbyCarId(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        [CacheAspect]
        public IDataResult<CarDetailDto> GetDetails(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetDetails(carId));
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();

        }


    }
}
