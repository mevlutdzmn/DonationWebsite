using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

//Entities veri tabanı tablolarının karşılığı 

namespace Entities.Concrete
{

    // diğer katmanlar erişsin diye public yapıldı
    // 
    public class Request : IEntity
    {
        public int RequestId { get; set; }
        public int CategoryId { get; set; }

        //cüzdan
        public string Wallet { get; set; }
        //talep tarihi
        //public DateTime Date { get; set; }
        //talep nedeni
        public string ReasonRequest { get; set; }
        //Toplanan yardım 
        public int CollectedAid { get; set; }

    }
}
