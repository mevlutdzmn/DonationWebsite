using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RequestImage:IEntity
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string ImagePath { get; set; }
    }
}
