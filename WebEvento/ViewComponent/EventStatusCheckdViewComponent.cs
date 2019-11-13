using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Data;

namespace WebEvento.ViewComponents
{
    public class EventStatusCheckdViewComponent:ViewComponent
    {
        WebDbContext db;
      
        public EventStatusCheckdViewComponent(WebDbContext Dbcontext)
        {
            db = Dbcontext;
         

        }
        //رویداد های بررسی شده
        public IViewComponentResult Invoke()
        {

            var obj = db.Event.Where(p => p.StatuseChecked == true);
            int? count = obj.ToList().Count;


            return Content(count.ToString());
         



            //return View(repository.Products
            //    .Select(x => x.Category)
            //    .Distinct()
            //    .OrderBy(x => x));
        }
    }
}
