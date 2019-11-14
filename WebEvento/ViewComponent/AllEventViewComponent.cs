using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
 
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Cashing;
using WebEvento.Data;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.ViewComponents
{
    public class AllEventViewComponent:ViewComponent
    {
        //تعداد کل رویداد ها
        private readonly CacheManager _cacheManager;
        public AllEventViewComponent(CacheManager cacheManage)
        {


            _cacheManager = cacheManage;

        }
        //کل رویداد ها
        public async Task<IViewComponentResult> InvokeAsync()
        {
        

            var menuItems = await _cacheManager.GetMenuItemsAsync();
            var obj = menuItems.ToList().Count();





            return Content(obj.ToString());




            //return View(repository.Products
            //    .Select(x => x.Category)
            //    .Distinct()
            //    .OrderBy(x => x));
        }
    }
}
