using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarDetailTest();

            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result = rentalManager.GetAll();
            //if (result.Success==true)
            //{
            //    foreach (var rent in result.Data)
            //    {
            //        Console.WriteLine(rent.CustomerId,rent.RentDate,rent.ReturnDate);
            //    }
            //}

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAllDetail();

            if (result.Success == true)
            {
                foreach (var carDetail in result.Data)
                {
                    Console.WriteLine("kiralayan : "+ carDetail.CustomerName + "araba : " +carDetail.CarName);
                }
            }

            //var result2 = rentalManager.Add(new Rental()
            //{
            //    CarId = 1,
            //    CustomerId = 1,
            //    RentDate = DateTime.Now,
            //    ReturnDate = DateTime.Now

            //});

           

        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetail();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Model: " + car.CarName + "| Fiyat : " + car.DailyPrice + "| Marka : " + car.BrandName + " | Renk :" + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
