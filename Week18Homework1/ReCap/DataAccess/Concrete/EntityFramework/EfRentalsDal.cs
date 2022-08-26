using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalsDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalsDal
    {
        public List<RentalsDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join u in context.Users
                             on r.CustomerId equals u.Id
                             join col in context.Colors
                             on c.ColorId equals col.Id
                             select new RentalsDetailDto
                             {
                                 CarId=c.Id,
                                 BrandId=b.Id,
                                 ColorId= col.Id,
                                 RentalId = r.Id,
                                 Amount=c.DailyPrice,
                                 BrandName=b.Name,
                                 ColorName=col.Name,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 UserId=u.Id,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate

                             };
                var list = result.ToList();
                return result.ToList();
            }
        }
    }
}
