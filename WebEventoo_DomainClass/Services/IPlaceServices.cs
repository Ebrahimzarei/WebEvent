using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEventoo_DomainClasses.Services
{
 public   interface IPlaceServices
    {
        Task<IEnumerable<Place>> GetAllPlaceAsync();
        Task<Place> GetPlaceAsync(int? id);

        Task<Place> AddAsync(Place Place);
        Task<Place> UpdateAsync(Place Place);
        Task DeleteConfirmedAsync(int id);
    }
}
