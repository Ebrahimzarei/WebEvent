using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEventoo_DomainClasses.Services
{
  public  interface IReportServices
    {
        Task<IEnumerable<Report>> GetAllReportAsync();
        Task<Report> GetReportAsync(int? id);

        Task<Report> AddAsync(Report Report);
        Task<Report> UpdateAsync(Report Place);
        Task DeleteConfirmedAsync(int id);
    }
}
