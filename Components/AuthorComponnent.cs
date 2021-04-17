using BookAudiomak.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bamak.Components
{
    public class AuthorComponnent : ViewComponent
    {

        private IGroupRepository _groupRepository;
        public AuthorComponnent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        




        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/AuthorComponnent.cshtml", _groupRepository.GetShowGroupAuthorName());

        }






    }
    
    
}
