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
           
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetail();

            if (result.Success==true)
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
