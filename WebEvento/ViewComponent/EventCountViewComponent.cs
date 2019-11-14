using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebEvento.Cashing;
using WebEvento.Data;

namespace WebEvento.ViewComponents
{

    public class EventCountViewComponent : ViewComponent
    {

        private readonly CacheManager _cacheManager;
        WebEvento.ViewModel.InformationViewModel vmodel;
        public EventCountViewComponent(CacheManager cacheManager)
        {
            _cacheManager= cacheManager;
            vmodel = new ViewModel.InformationViewModel();
        }
        //رویداد های بررسی نشده
        public async System.Threading.Tasks.Task<IViewComponentResult> InvokeAsync()
        {


            var menuItems = await _cacheManager.GetMenuItemsAsync();
            var obj = menuItems.Where(p => p.StatuseChecked != true).Count();
            vmodel.StatuseCheckedviewcomponent = obj;
            return Content(obj.ToString());

         //   return View(vmodel.StatuseCheckedviewcomponent);
           

           
          
        }

    }

}