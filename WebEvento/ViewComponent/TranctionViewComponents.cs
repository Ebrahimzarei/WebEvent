using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Data;

namespace WebEvento.ViewComponents
{
    /// <summary>
    /// مجموع تراکنش های امروز
    /// </summary>
    public class TranctionViewComponents : Microsoft.AspNetCore.Mvc.ViewComponent
    {

        private readonly IServiceProvider _serviceProvider;
        ViewModel.InformationViewModel vmodel;
        public TranctionViewComponents(IServiceProvider serviceProvide)
        {
            _serviceProvider = serviceProvide;
            vmodel = new ViewModel.InformationViewModel();
        }
        public IViewComponentResult Invoke()
        {
            PersianCalendar pc = new PersianCalendar();
            var dtnow = DateTime.Now;

                DateTime dt = new DateTime(dtnow.Year, dtnow.Month, dtnow.Day); // یا DateTime.Now
          

                string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));

 

            int? count;
            using (var scope = _serviceProvider.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<WebDbContext>();

                count = dataContext.TranctionEvent.Where(x => x.DateTime == PersianDate).ToList().Count();
            }


            vmodel.StatuseCheckedviewcomponent = count;

           
            return Content(vmodel.StatuseCheckedviewcomponent.ToString());
        }
        }
    }
