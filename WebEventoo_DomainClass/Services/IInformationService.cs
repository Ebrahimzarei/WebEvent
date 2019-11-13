using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEventoo_DomainClasses.Services
{
 public   interface IInformationService
    {
        Task<IEnumerable<Information>> GetAllInformationAsync();
        Task<List<Information>> GetAllInformationListAsync();
        Task<Information> GetInformationAsync(int? id);

        Task<Information> AddAsync(Model.Information Information);
        Task<Information> UpdateAsync(Information Information);
        Task DeleteConfirmedAsync(int id);
    }
}
