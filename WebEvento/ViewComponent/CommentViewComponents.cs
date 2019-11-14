using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Data;

namespace WebEvento.ViewComponents
{
    //تعدادرویداد های منتشر نشده

    public class NotPublishedViewComponents : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IServiceProvider _serviceProvider;
        ViewModel.InformationViewModel vmodel;
        public NotPublishedViewComponents(IServiceProvider serviceProvide)
        {
            _serviceProvider = serviceProvide;
            vmodel = new ViewModel.InformationViewModel();
        }
        //تعداد   رویداد های منتشر نشده
        public IViewComponentResult Invoke()
        {
            int? count;
            using (var scope = _serviceProvider.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<WebDbContext>();

                count = dataContext.NotPublished.ToList().Count;
            }
         

            vmodel.StatuseCheckedviewcomponent = count;
            return Content(vmodel.StatuseCheckedviewcomponent.ToString());




        }
    }
}
