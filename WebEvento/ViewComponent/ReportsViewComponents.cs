using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;
        public ReportsViewComponents(IServiceProvider serviceProvide)
        {
            _serviceProvider = serviceProvide;
            vmodel = new ViewModel.InformationViewModel();
        }
        public IViewComponentResult Invoke()
        {
            int? count;
            using (var scope = _serviceProvider.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<WebDbContext>();

                count = dataContext.Report.Where(x => x.RoleReport == WebEventoo_DomainClasses.Model.Report.TypeReport.ReportEvent).ToList().Count();
            }


            vmodel.StatuseCheckedviewcomponent = count;


          
            return Content(vmodel.StatuseCheckedviewcomponent.ToString());




        }
    }
}
