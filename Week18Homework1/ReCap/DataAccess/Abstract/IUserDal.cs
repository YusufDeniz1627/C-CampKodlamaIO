﻿using Core.DataAccess;
using Core.Entities.Concrete;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
