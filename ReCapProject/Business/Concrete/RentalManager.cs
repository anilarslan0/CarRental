using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.Utilities.Business;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal,ICarService carService,ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfCarExist(rental.CarId),IsCarAvaliable(rental.CarId));
            if (result!=null)
            {
                return new ErrorResult("Kiralama Yapılamadı");
            }
            _rentalDal.Add(rental);
            return new SuccessResult("Kiralama İşlemi Başarılı");
        }

        public IResult Delete(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfCarExist(rental.RentalId));

            if (result!=null)
            {
                return new ErrorResult("Kiralık Araç Silinemedi");
            }

            _rentalDal.Delete(rental);
            return new SuccessResult("Kiralık Araç Silindi");
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentCarDetailDto>> GetAllDetail()
        {
            return new SuccessDataResult<List<RentCarDetailDto>>(_rentalDal.GetRentalDetails());
        }


        public IDataResult<Rental> GetByRentalId(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IDataResult<List<Rental>> GetListReturnDateIsNull()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfCarExist(rental.RentalId));

            if (result!=null)
            {
                return new ErrorResult("Kiralama Güncellenemedi");
            }

            var result2 = BusinessRules.Run(CheckIfCarExist(rental.CarId));
            if (result!=null)
            {
                return new ErrorResult("Kiralama Güncellenemedi");
            }

            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        private IResult CheckIfCarExist(int carId)
        {
            var result = _carService.GetbyCarId(carId);
            if (result !=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult IsCarAvaliable(int carId)
        {
            var result = _rentalDal.Any(x => x.CarId == carId && (x.ReturnDate == null || x.ReturnDate <= DateTime.Now));
            if (result)
            {
                return new ErrorResult(Messages.CarIsNotAvaliable);
            }
            return new SuccessResult();
        }


        private IResult CheckIsRentalExits(int rentalId)
        {
            var result = _rentalDal.Any(x => x.RentalId == rentalId);
            if (!result)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

     
    }
}
