using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        //productla ilgili veri tabanında yapacağım işlemleri yapan interface
        List<Car> GetAll();

        List<Car> GetById(int carId);

        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);

    }
}
