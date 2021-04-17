using BookAudiomak.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bamak.Components
{
    public class SliderComponnet : ViewComponent
    {
        private IGroupRepository _groupRepository;
        public SliderComponnet(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/SliderComponnet.cshtml", _groupRepository.GetNewproductSlider());

        }
    }
}
