using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAudiomak.Data;
using BookAudiomak.Data.Repository;
using BookAudiomak.Models;
using Microsoft.AspNetCore.Mvc;


namespace Bamak.Components
{
    public class ProductGroupsComponent : ViewComponent
    {

        private IGroupRepository _groupRepository;
        public ProductGroupsComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/ProductGroupsComponent.cshtml", _groupRepository.GetShowGroupViewModels());

        }




        //public async Task<IViewComponentResult> InvokeAsyncA()
        //{
        //    return View("/Views/Components/ProductGroupsComponent.cshtml", _groupRepository.GetShowGroupAuthorName());

        //}

    }
}
