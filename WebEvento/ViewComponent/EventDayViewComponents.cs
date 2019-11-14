using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Cashing;
using WebEvento.Data;
 

namespace WebEvento.ViewComponents
{
    /// <summary>
    /// رویداد های امروز
    /// </summary>
    public class EventDayViewComponents : Microsoft.AspNetCore.Mvc.ViewComponent
    {

        private readonly CacheManager _cacheManager;
        public EventDayViewComponents(CacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }
        //تعداد   رویداد های  امروز
        public async Task<IViewComponentResult> InvokeAsync()
        {

            PersianCalendar pc = new PersianCalendar();
            string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();

          


            var menuItems = await _cacheManager.GetMenuItemsAsync();
            var obj = menuItems.Where(x => x.TimeEvent == PDate).Count();




            return Content(obj.ToString());




        }
    }
}
