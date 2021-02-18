using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
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
