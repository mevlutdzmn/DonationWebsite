using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RequestDetailDto:IDto
    {
        public int RequestId { get; set; }
        public string CategoryName { get; set; }
        public string Wallet { get; set; }
        public string ReasonRequest { get; set; }
        //Toplanan yardım 
        public int CollectedAid { get; set; }
    }
}
