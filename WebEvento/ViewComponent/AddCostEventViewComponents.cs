using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Data;

namespace WebEvento.ViewComponents
{
    //رویداد های  نیاز به پرداخت
    public class PayedEventEventViewComponents:ViewComponent
    {
        WebDbContext db;
        ViewModel.InformationViewModel vmodel;
        public PayedEventEventViewComponents(WebDbContext Dbcontext)
        {
            db = Dbcontext;
            vmodel = new ViewModel.InformationViewModel();

        }
        //رویداد های  نیاز به پرداخت
        public IViewComponentResult Invoke()
        {

            var obj = db.Event.Where(p => p.Statusevent ==WebEventoo_DomainClasses.Model.Event.StatuseEvent.Ispayed);

            vmodel.StatuseCheckedviewcomponent = obj.ToList().Count;
            return Content(vmodel.StatuseCheckedviewcomponent.ToString());


        }
    }
}
