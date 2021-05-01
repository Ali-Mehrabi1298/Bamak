using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookAudiomak.Models;
using BookAudiomak.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using BookAudiomak.Data.Repository;

using Microsoft.AspNetCore.Identity;

namespace BookAudiomak.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Bookmakcontex _context;
        private IGroupRepository _groupRepository; 
        public HomeController(ILogger<HomeController> logger, Bookmakcontex contex,IGroupRepository groupRepository)
        {
            _logger = logger;
            _context = contex;
            _groupRepository = groupRepository;
        }

        public IActionResult Index()
        {
            var products = _context.products.ToList();
            //.Include(p => p.item)

            return View(products);
        }
        //[HttpPost]
    








        public async Task<IActionResult> Search (string searchString)
        {
            var movies = from m in _context.products
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Name.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }


        public IActionResult Detail(int id)
        {


            var product = _context.products
                 //.Include(p => p.item)
                 .SingleOrDefault(p => p.ItemId==id);



            // .Select(ca => ca.category).ToList();

            if (product == null)
            {
                return NotFound();
            }

            var Name = product.Name;

            var File = _context.Filess.Where(D=>D.productName==Name).ToList();

            var Categoress = _context.products.Where(A => A.Id == id).SelectMany(s => s.categoryToProducts)
              .Select(ca => ca.category).ToList();

         

            var pro = new AddDetailView()
            {

                product = product,
                categories = Categoress,
                Filess = File


            };

            return View(pro);


        }


    

        [Authorize]
        public IActionResult AddToCart(int itemId)
        {

           
            
                var product = _context.products/*Include(p => p.item)*/.SingleOrDefault(p => p.ItemId == itemId);
                if (product != null)
            {
                //var userId = /*int.Parse*/(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                //var userId = _context.Users.Where(p=>p.Id==);



                var order = _context.orders.FirstOrDefault(o => o.username ==User.Identity.Name && !o.IsFinaly);
                if (order != null)
                {
                        var orderDetail =
                            _context.orderDetails.FirstOrDefault(d =>
                                d.OrderId == order.OrderId && d.ProductId == product.Id);
                        if (orderDetail != null)
                        {
                            orderDetail.Count += 1;
                        }
                        else
                        {
                            _context.orderDetails.Add(new OrderDetail()
                            {
                                OrderId = order.OrderId,
                                ProductId = product.Id,
                                Price = product.Price,
                                Count = 1
                            });
                        }
                    }
                    else
                    {



                        order = new Order()
                        {
                            IsFinaly = false,
                            dateTime = DateTime.Now,
                            username = User.Identity.Name
                        };
                        _context.orders.Add(order);
                        _context.SaveChanges();
                        _context.orderDetails.Add(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = product.Id,
                            Price = product.Price,
                            Count = 1
                        });
                    }

                    _context.SaveChanges();
                }


                return RedirectToAction("ShowCart");
            }
        


        [Authorize]
        public IActionResult ShowCart()
        {
            var userId = /*int.Parse*/(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.orders.Where(o => o.username == User.Identity.Name && !o.IsFinaly)
                .Include(o => o.OrderDetails)
                .ThenInclude(c => c.Product).FirstOrDefault();


            return View(order);
        }

        [Authorize]
        public IActionResult RemoveCart(int detailId)
        {

            var orderDetail = _context.orderDetails.Find(detailId);
            _context.Remove(orderDetail);
            _context.SaveChanges();

            return RedirectToAction("ShowCart");
        }





      


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
