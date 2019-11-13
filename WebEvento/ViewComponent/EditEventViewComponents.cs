using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Data;

namespace WebEvento.ViewComponents
{
    public class EditEventViewComponents: ViewComponent
    {
        WebDbContext db;
        ViewModel.InformationViewModel vmodel;
        public EditEventViewComponents(WebDbContext Dbcontext)
        {
            db = Dbcontext;
            vmodel = new ViewModel.InformationViewModel();

        }
        //رویداد های نیاز به تغییرات
        public IViewComponentResult Invoke()
        {

            var obj = db.Event.Where(p => p.Statusevent==WebEventoo_DomainClasses.Model.Event.StatuseEvent.IsEdit);

            vmodel.StatuseCheckedviewcomponent = obj.ToList().Count;
            return Content(vmodel.StatuseCheckedviewcomponent.ToString());




        }
    }
}
