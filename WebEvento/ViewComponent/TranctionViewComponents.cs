using Microsoft.AspNetCore.Mvc;
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
        ViewModel.InformationViewModel vmodel;
        WebDbContext db;
        public TranctionViewComponents(WebDbContext Dbcontext)
        {
            db = Dbcontext;
            vmodel = new ViewModel.InformationViewModel();
        }
        public IViewComponentResult Invoke()
        {
            PersianCalendar pc = new PersianCalendar();
            var dtnow = DateTime.Now;

                DateTime dt = new DateTime(dtnow.Year, dtnow.Month, dtnow.Day); // یا DateTime.Now
          

                string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));


            var obj = db.TranctionEvent.Where(x => x.DateTime == PersianDate);

            vmodel.StatuseCheckedviewcomponent = obj.ToList().Count;
            return Content(vmodel.StatuseCheckedviewcomponent.ToString());
        }
        }
    }
