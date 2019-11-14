using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Cashing;
using WebEvento.Data;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.ViewComponents
{
    //رویداد های نردبان شده
    public class LadderViewComponents:ViewComponent
    {

        private readonly CacheManager _cacheManager;
        public LadderViewComponents(CacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }
        //رویداد های نردبان شده
        public async Task<IViewComponentResult> InvokeAsync()
        {
         


            var menuItems = await _cacheManager.GetMenuItemsAsync();
            var obj = menuItems.Where(x => x.Statusevent == Event.StatuseEvent.Ladder).ToList().Count();


            return Content(obj.ToString());




        }
    }
}
