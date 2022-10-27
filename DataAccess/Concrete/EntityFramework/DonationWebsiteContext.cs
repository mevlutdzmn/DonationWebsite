using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağlar
    //DbContext : entityframeworkten geliyor
    public class DonationWebsiteContext:DbContext
    {
        // bu methodu  projen hangi veri tabanı ile ilişkili 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;DataBase=DonationDb;Trusted_Connection=true");
        }

        //hangi class hangi tabloya karşılık geliyor
        public DbSet<Request> Requests { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
