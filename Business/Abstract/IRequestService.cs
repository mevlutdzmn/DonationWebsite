﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRequestService
    {
        List<Request> GetAll();
        //kategori id sine  göre listele
        List<Request> GetByCategoryId(int id);
        List<Request> GetByCollectedAid(double collectedAid);
    }
}
