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
    public class EventStatusCheckdViewComponent:ViewComponent
    {
   

        private readonly CacheManager _cacheManager;

        public EventStatusCheckdViewComponent(CacheManager cacheManager)
        {

            _cacheManager = cacheManager;

        }
        //رویداد های بررسی شده
        public async Task<IViewComponentResult> InvokeAsync()
        {
        


            var menuItems = await _cacheManager.GetMenuItemsAsync();
            var obj = menuItems.Where(p => p.StatuseChecked == true).ToList().Count();




            return Content(obj.ToString());
         



            //return View(repository.Products
            //    .Select(x => x.Category)
            //    .Distinct()
            //    .OrderBy(x => x));
        }
    }
}
