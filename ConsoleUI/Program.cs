using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestManager requestManager = new RequestManager(new InMemoryRequestDal());

            foreach (var request in requestManager.GetAll())
            {
                Console.WriteLine(request.ReasonRequest);
            }
            
        }
    }
}
