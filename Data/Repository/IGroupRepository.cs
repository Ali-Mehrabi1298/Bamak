using Bamak.Models;
using BookAudiomak.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAudiomak.Data.Repository
{
    public interface IGroupRepository
    {
        public IEnumerable<Category> GetAllCategory();
        public void GetAll(Filess filess);
        public IEnumerable<Product> GetAllProduct(string Name);
        public IEnumerable<ShowGroupViewModel> GetShowGroupViewModels();
        public IEnumerable<Showproduct> GetShowGroupAuthorName();
        public IEnumerable<Showslider> GetNewproductSlider();

    }

    public class GroupRepository : IGroupRepository
    {
        private Bookmakcontex _context;
        public GroupRepository(Bookmakcontex context)
        {
            _context = context;
        }


        public void GetAll(Filess Filee)
        {
            _context.Filess.Add(Filee);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _context.categories;
        }

        public IEnumerable<Product> GetAllProduct(string Name)
        {

            return _context.products.Where(d => d.Name == Name);
        }


        //public Product GetAllName(string Name)
        //{
        //    return _context.products.SingleOrDefault(k => k.Name == Name);
        //}

        public IEnumerable<ShowGroupViewModel> GetShowGroupViewModels()
        {
            return _context.categories.Select(c => new ShowGroupViewModel()
            {

                GroupId = c.Id,
                Name = c.Name,
                ProductCount = _context.categoryToProducts.Count(g => g.categoryId == c.Id)
            }).ToList();
        }



        public IEnumerable<Showproduct> GetShowGroupAuthorName()
        {
            return _context.AuthorNames.Select(c => new Showproduct()
            {

                GroupId = c.Id,
                AthoureName = c.Name,
                ProductCount = _context.categoryToProducts.Count(g => g.AuthorId == c.Id)
            }).ToList();
        }




        public IEnumerable<Showslider> GetNewproductSlider()
        {
            return _context.slidNew_Producs.Select(c => new Showslider()
            {

                Id = c.Id,
                NewBookName = c.NewBookName,
                count = _context.PRODUCTTOSLIDERs.Count(g => g.SlidNew_producId == c.Id)
            }).ToList();


        }
        }
}



