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
    public class EditEventViewComponents: ViewComponent
    {

        private readonly CacheManager _cacheManager;
        public EditEventViewComponents(CacheManager cacheManager)
        {
            _cacheManager = cacheManager;
          
      

        }
        //رویداد های نیاز به تغییرات
        public async Task<IViewComponentResult> InvokeAsync()
        {
    
              //  var obj = dataContext.Event.Where(p => p.Statusevent == WebEventoo_DomainClasses.Model.Event.StatuseEvent.IsEdit);
                var menuItems = await _cacheManager.GetMenuItemsAsync();
                var obj = menuItems.Where(p => p.Statusevent == WebEventoo_DomainClasses.Model.Event.StatuseEvent.IsEdit).ToList().Count();
            
         


      

           
       
            return Content(obj.ToString());




        }
    }
}
