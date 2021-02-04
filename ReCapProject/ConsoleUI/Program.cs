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

            //Bir kere ekledim ve durdurdum. İstersem manuel gidip veri tabanını doldurabilirim.
            //carManager.Add(new Entities.Concrete.Car { CarId=1, BrandId = 1, ColorId = 1, DailyPrice = 15000, ModelYear = 2015, Description = "Good Car", CarName = "Fıat" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Marka : " + car.CarName+ "| Fiyat : "+car.DailyPrice+ "| Açıklama : " + car.Description);
            }
        }
    }
}
