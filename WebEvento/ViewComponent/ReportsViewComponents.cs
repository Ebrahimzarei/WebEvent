using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Data;

namespace WebEvento.ViewComponents
{
    /// <summary>
    /// رویداد های گزارش شده
    /// </summary>
    public class ReportsViewComponents : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        ViewModel.InformationViewModel vmodel;
        WebDbContext db;
        public ReportsViewComponents(WebDbContext Dbcontext)
        {
            db = Dbcontext;
            vmodel = new ViewModel.InformationViewModel();
        }
        public IViewComponentResult Invoke()
        {
         
           

            var obj = db.Report.Where(x=>x.RoleReport==WebEventoo_DomainClasses.Model.Report.TypeReport.ReportEvent);

            vmodel.StatuseCheckedviewcomponent = obj.ToList().Count;
            return Content(vmodel.StatuseCheckedviewcomponent.ToString());




        }
    }
}
