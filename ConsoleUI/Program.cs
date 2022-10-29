using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        //SOLİD prensiplerine uyuldu
        //open closed principle yapıldı ,özellik eklenince mevcut kodu değiştirme
        static void Main(string[] args)
        {
            RequestManager requestManager = new RequestManager(new EFRequestDal());

            foreach (var request in requestManager.GetByCategoryId(2))
            {
                Console.WriteLine(request.ReasonRequest); 
            }
            
        }
    }
}
