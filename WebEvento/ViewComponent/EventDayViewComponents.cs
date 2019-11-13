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
    /// رویداد های امروز
    /// </summary>
    public class EventDayViewComponents : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        WebDbContext db;
        ViewModel.InformationViewModel vmodel;
        public EventDayViewComponents(WebDbContext Dbcontext)
        {
            db = Dbcontext;
            vmodel = new ViewModel.InformationViewModel();
        }
        //تعداد   رویداد های  امروز
        public IViewComponentResult Invoke()
        {

            PersianCalendar pc = new PersianCalendar();
            string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();

           

            var obj = db.Event.Where(x=>x.TimeEvent== PDate);

            vmodel.StatuseCheckedviewcomponent = obj.ToList().Count;
            return Content(vmodel.StatuseCheckedviewcomponent.ToString());




        }
    }
}
