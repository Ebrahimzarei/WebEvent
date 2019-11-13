using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebEvento.Data;

namespace WebEvento.ViewComponents
{

    public class EventCountViewComponent : ViewComponent
    {
        WebDbContext db;
        ViewModel.InformationViewModel vmodel;
        public EventCountViewComponent(WebDbContext Dbcontext)
        {
            db = Dbcontext;
            vmodel = new ViewModel.InformationViewModel();

        }
        //رویداد های بررسی نشده
        public IViewComponentResult Invoke()
        {
       
            var obj = db.Event.Where(p => p.StatuseChecked != true);
           
                vmodel.StatuseCheckedviewcomponent = obj.ToList().Count;
                return View(vmodel);
           

           
          
        }

    }

}