
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Cashing;
using WebEvento.Data;

namespace WebEvento.ViewComponents
{
    //رویداد های  نیاز به پرداخت
    public class PayedEventEventViewComponents:ViewComponent
    {
       
       
     
        private readonly CacheManager _cacheManager;
        public PayedEventEventViewComponents( CacheManager cacheManager)
        {
            _cacheManager = cacheManager;
         
          
          

        }
        //رویداد های  نیاز به پرداخت
        public async Task<IViewComponentResult> InvokeAsync()
        {
         

            var menuItems = await _cacheManager.GetMenuItemsAsync();
            var obj=   menuItems.Where(p => p.Statusevent == WebEventoo_DomainClasses.Model.Event.StatuseEvent.Ispayed).ToList().Count();
            return Content(obj.ToString());


        }
    }
}
