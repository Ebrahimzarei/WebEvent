using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Data;

namespace WebEvento.ViewComponents
{
    public class SliderViewComponents:ViewComponent
    {
        WebDbContext db;
        ViewModel.InformationViewModel vmodel;
        public SliderViewComponents(WebDbContext Dbcontext)
        {
            db = Dbcontext;
            vmodel = new ViewModel.InformationViewModel();

        }
        //تعداد رویداد های اسلایدر
        public IViewComponentResult Invoke()
        {
            var m = DateTime.Now.ToString();


            var obj = db.Event.Where(p => p.Statusevent==WebEventoo_DomainClasses.Model.Event.StatuseEvent.Slider);

            vmodel.StatuseCheckedviewcomponent = obj.ToList().Count;
            return Content(vmodel.StatuseCheckedviewcomponent.ToString());




        }
    }
}
