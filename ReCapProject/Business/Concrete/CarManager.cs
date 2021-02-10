using Business.Abstract;
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

        public void Add(Car car)
        {
            if (car.CarName.Length>=2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Arabanızın Adını ve Günlük Ücretini Lütfen Kontrol Ediniz");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int Id)
        {
            return _carDal.GetAll(c=>c.BrandId==Id);
        }

        public List<Car> GetAllByColorId(int Id)
        {
            return _carDal.GetAll(c => c.ColorId == Id);
        }

        public Car GetbyCarId(int carId)
        {
            return _carDal.Get(c=>c.CarId==carId);
        }

        public List<CarDetailDto> GetCarDetail()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
