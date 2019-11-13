using Microsoft.AspNetCore.Mvc;
using System;
 
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Data;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.ViewComponents
{
    public class AllEventViewComponent:ViewComponent
    {
        WebDbContext db;
      
        ViewModel.InformationViewModel vmodel;
        public AllEventViewComponent(WebDbContext Dbcontext)
        {
            db = Dbcontext;
           
            vmodel = new ViewModel.InformationViewModel();

        }
        //کل رویداد ها
        public  IViewComponentResult Invoke()
        {
      

            var obj = db.Event;
         
            
            int? count = obj.ToList().Count;


            return Content(count.ToString());




            //return View(repository.Products
            //    .Select(x => x.Category)
            //    .Distinct()
            //    .OrderBy(x => x));
        }
    }
}
