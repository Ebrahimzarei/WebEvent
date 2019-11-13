using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Data;

namespace WebEvento.ViewComponents
{
    public class SpecialEventViewComponents:ViewComponent
    {
        WebDbContext db;
        ViewModel.InformationViewModel vmodel;
        public SpecialEventViewComponents(WebDbContext Dbcontext)
        {
            db = Dbcontext;
            vmodel = new ViewModel.InformationViewModel();

        }
        //رویداد های ویژه
        public IViewComponentResult Invoke()
        {

            var obj = db.Event.Where(p => p.Statusevent == WebEventoo_DomainClasses.Model.Event.StatuseEvent.Special);

            vmodel.StatuseCheckedviewcomponent = obj.ToList().Count;
            return Content(vmodel.StatuseCheckedviewcomponent.ToString());




        }
    }
}
