using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEventoo_DomainClasses.Services
{
   public interface IEductionservices
    {
        Task<IEnumerable<Eduction>> GetAllEductionAsync();
        Task<Eduction> GetEductionAsync(int? id);

        Task<Eduction> AddAsync(Eduction Eduction);
        Task<Eduction> UpdateAsync(Eduction Eduction);
        Task DeleteConfirmedAsync(int id);

    }
}
