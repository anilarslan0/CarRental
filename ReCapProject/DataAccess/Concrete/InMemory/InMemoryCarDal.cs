using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
            new Car {CarId=1,BrandId=1,ColorId=1,ModelYear=2014,DailyPrice=75000,Description="Good Car" },
            new Car {CarId=2,BrandId=1,ColorId=1,ModelYear=2016,DailyPrice=85000,Description="Good Car" },
            new Car {CarId=3,BrandId=2,ColorId=2,ModelYear=2018,DailyPrice=95000,Description="Good Car" },
            new Car {CarId=4,BrandId=2,ColorId=2,ModelYear=2017,DailyPrice=65000,Description="Good Car" },
            new Car {CarId=5,BrandId=2,ColorId=3,ModelYear=2015,DailyPrice=80000,Description="Good Car" },

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p=>p.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId == carId).ToList();
        }

        public void Update(Car car)
        {   //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
