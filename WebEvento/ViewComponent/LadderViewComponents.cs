using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Data;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.ViewComponents
{
    //رویداد های نردبان شده
    public class LadderViewComponents:ViewComponent
    {
        ViewModel.InformationViewModel vmodel;
        WebDbContext WebDbContext;
        public LadderViewComponents(WebDbContext  DbContext)
        {
            WebDbContext =  DbContext;
            vmodel = new ViewModel.InformationViewModel();
        }
        //رویداد های نردبان شده
        public IViewComponentResult Invoke()
        {

            var obj = WebDbContext.Event.Where(x=>x.Statusevent==Event.StatuseEvent.Ladder).ToList();
           
 
           
            vmodel.StatuseCheckedviewcomponent = obj.Count;
            return Content(vmodel.StatuseCheckedviewcomponent.ToString());




        }
    }
}
