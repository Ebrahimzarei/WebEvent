using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Cashing;
using WebEvento.Data;

namespace WebEvento.ViewComponents
{
    public class SpecialEventViewComponents:ViewComponent
    {

        private readonly CacheManager _cacheManager;
        public SpecialEventViewComponents(CacheManager cacheManager)
        {
            _cacheManager = cacheManager;

        }
        //رویداد های ویژه
        public async Task<IViewComponentResult> InvokeAsync()
        {

  


            var menuItems = await _cacheManager.GetMenuItemsAsync();
            var obj = menuItems.Where(p => p.Statusevent == WebEventoo_DomainClasses.Model.Event.StatuseEvent.Special).ToList().Count();



            return Content(obj.ToString());




        }
    }
}
