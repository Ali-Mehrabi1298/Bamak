using Bamak.Models;
using BookAudiomak.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace BookAudiomak.Data
{
    public class Bookmakcontex : IdentityDbContext
    {

        //public Bookmakcontex(DbContextOptions<Bookmakcontex> options) : base(options)
        //{

        //}
        public Bookmakcontex(DbContextOptions dbContextOptions)
         : base(dbContextOptions)
        {

        }

   

        public DbSet<AuthMessageSenderOptions> AuthMessageSenderOptions { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<CategoryToProduct> categoryToProducts { get; set; }
        public DbSet<CategoreAuthorName> AuthorNames { get; set; }
        //public DbSet<Item> items { get; set; }
        //public DbSet<Users> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Filess> Filess { get; set; }
        public DbSet<PdfModel> PdfModels { get; set; }
        public DbSet<SlidNew_produc> slidNew_Producs { get; set; }
        public DbSet<PRODUCTTOSLIDER> PRODUCTTOSLIDERs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<CategoryToProduct>().HasKey(p => new { p.ProductId, p.categoryId, p.AuthorId });
            modelBuilder.Entity<PRODUCTTOSLIDER>().HasKey(p => new { p.ProductId, p.SlidNew_producId });

            #region Seed Data Category


            modelBuilder.Entity<Product>().HasData(new Product()
            {

                Id = 1,
                Name = "اثرمرکب",
                Description = "کتاب اثرمرکب از دارن هاردی یکی از بهترین کتاب هایی در جهت موفقیت است که به شدت توصیه میشود که مطالعه شود،دارن هاردی در این کتاب سعی میکند که راز های موفقیت را با بقیه به اشتراک بگذارد و شما میتوانید با ایناز این کتاب  برای موفقیتتن استفاده نمایید  ",
                AutherName = "دارن هاردی",
      
                ItemId=1

            },




                new Product()
                {

                    Id = 2,
                    Name = "هفت عادت مردمان موثر",
                    Description = "کتاب هفت عادت مردمان موثر از استفان کاوی کتاب فوق العاده ایی در جهت کمک به موفقیت و استقلال یافتن در زندگی و پیشرفت ها و به نوعی خود ساختگی است و البته برای تمرکز بیشتر بر روی خود",
                    AutherName = "استفان کاوی",
            
                     
                    ItemId = 2

                }, new Product()
                {

                    Id = 3,
                    Name = "کیمیا گر",
                    Description = "  رمان کیمیاگراز پايولینیو کوئیلو کتاب شیرین و دلنشینی است که نویسنده سعی دارد در این کتاب به ما بگویید که دنیا پر از نشانه هایی ب رای انجام کارهای ما هستن که به ما می گویند چه کارهایی را انجام دهیم نویسنده این مسائل را در قالب رمان ارائه کرده است",
                    AutherName = "پائولیوکولیو",
              
                     
                    ItemId = 3

                });

         //   modelBuilder.Entity<Item>().HasData(
         //    new Item()
         //    {
         //        Id = 1,
         //        Price = 854.0M,
         //        //QuantityInStock = 5
         //    },
         //new Item()
         //{
         //    Id = 2,
         //    Price = 3302.0M,
         //    //QuantityInStock = 8
         //},
         //new Item()
         //{
         //    Id = 3,
         //    Price = 2500,
         //    //QuantityInStock = 3
         //});


            modelBuilder.Entity<Category>().HasData(new Category

            {

                Id = 1,
                Name = "روانشناسی",
                Description = "ایی در جهت کمک به موفقیت و استقلال یافتن در زندگی و پیشرفت ها و به نوعی خود ساختگی است و البته برای تمرکز بیشتر بر روی خود",



            },

            new Category
            {


                Id = 2,
                Name = "تاریخی ",
                Description = "کتاب هفت عادت مردمان موثر از استفان کاوی کتاب فوق العاده ایی در جهت کمک به موفقیت و استقلال یافتن در زندگی و پیشرفت ها و به نوعی خود ساختگی است و البته برای تمرکز بیشتر بر روی خود",



            },
              new Category
              {


                  Id = 3,
                  Name = "رمان ",

                  Description = "  رمان کیمیاگراز پايولینیو کوئیلو کتاب شیرین و دلنشینی است که نویسنده سعی دارد در این کتاب به ما بگویید که دنیا پر از نشانه هایی ب رای انجام کارهای ما هستن که به ما می گویند چه کارهایی را انجام دهیم نویسنده این مسائل را در قالب رمان ارائه کرده است",


              }

                );

            var unused = modelBuilder.Entity<CategoryToProduct>().HasData
                (
                new CategoryToProduct { categoryId = 1, ProductId = 1, AuthorId = 1 },
                new CategoryToProduct { categoryId = 2, ProductId = 2, AuthorId = 2 },
                new CategoryToProduct { categoryId = 3, ProductId = 3, AuthorId = 3 }

                );






            #endregion 








            base.OnModelCreating(modelBuilder);
        }


    }
}