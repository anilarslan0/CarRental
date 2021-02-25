using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntitiyRepositoryBase<Rental, CarDbContext>, IRentalDal
    {
        public List<RentCarDetailDto> GetRentalDetails()
        {
            using (CarDbContext context=new CarDbContext())
            {
                var result = from c in context.Customers
                             join r in context.Rentals
                             on
                             c.CustomerId equals r.CustomerId
                             join u in context.Users
                             on
                             c.UserId equals u.UserId
                             join k in context.Cars
                             on
                             r.CarId equals k.CarId
                             select new RentCarDetailDto()
                             {   
                                 RentalId=r.RentalId,
                                 CustomerName = u.UserFirstName,
                                 CarName = k.CarName,
                                 UserName = u.UserFirstName,
                                 CompanyName = c.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };


                return result.ToList();
            }
        }
    }
}
