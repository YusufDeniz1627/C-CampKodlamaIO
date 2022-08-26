using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        CarDetailDto GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);

        List<CarDetailDto> GetCarDetailDto(Expression<Func<CarDetailDto, bool>> filter = null);
     
    }
}
