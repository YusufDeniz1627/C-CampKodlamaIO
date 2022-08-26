using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDto(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join r in context.Colors
                             on c.ColorId equals r.Id
                             select new CarDetailDto
                             {
                                 carId = c.Id,
                                 ModelYear = c.ModelYear,
                                 BrandId = b.Id,
                                 ColorId = r.Id,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = r.Name,
                                 DailyPrice = c.DailyPrice,
                                 Detail = c.Detail,
                                 imagePath = (from img in context.CarImages where img.CarId == c.Id select img.ImagePath).FirstOrDefault(),
                                 imageList = (from i in context.CarImages
                                              where (c.Id == i.CarId)
                                              select new CarImages { Id = i.Id, CarId = c.Id, ImageDate = i.ImageDate, ImagePath = i.ImagePath }).ToList()
                             };
                return filter == null
              ? result.ToList()
              : result.Where(filter).ToList();
            }
        }

        public CarDetailDto GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join r in context.Colors
                             on c.ColorId equals r.Id
                             select new CarDetailDto {
                                 carId=c.Id,
                                 ModelYear = c.ModelYear,
                                 BrandId = b.Id,
                                 ColorId = r.Id,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = r.Name,
                                 DailyPrice = c.DailyPrice,                               
                                 Detail=c.Detail,
                                 imagePath = (from img in context.CarImages where img.CarId == c.Id select img.ImagePath).FirstOrDefault(),
                                 imageList= (from i in context.CarImages
                                            where (c.Id == i.CarId)
                                            select new CarImages { Id = i.Id, CarId = c.Id, ImageDate = i.ImageDate, ImagePath = i.ImagePath }).ToList()
                             };
            return filter == null
          ? result.SingleOrDefault()
          : result.Where(filter).SingleOrDefault();

        }
        }
    }
}
