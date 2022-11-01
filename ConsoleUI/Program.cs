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
            //IoC uygulanacak
            //requestin testinin bu method ile yaptık methoh haline getidik,altaki method
            //RequestTest();
            // CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void RequestTest()
        {
            RequestManager requestManager = new RequestManager(new EfRequestDal());

            foreach (var request in requestManager.GetByCategoryId(2))
            {
                Console.WriteLine(request.ReasonRequest);
            }
        }
    }
}
