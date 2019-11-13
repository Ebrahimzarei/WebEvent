using Microsoft.AspNetCore.Mvc;
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
        WebDbContext db;
        ViewModel.InformationViewModel vmodel;
        public NotPublishedViewComponents(WebDbContext Dbcontext)
        {
            db = Dbcontext;
            vmodel = new ViewModel.InformationViewModel();
        }
        //تعداد   رویداد های منتشر نشده
        public IViewComponentResult Invoke()
        {

            var obj = db.NotPublished;

            vmodel.StatuseCheckedviewcomponent = obj.ToList().Count;
            return Content(vmodel.StatuseCheckedviewcomponent.ToString());




        }
    }
}
