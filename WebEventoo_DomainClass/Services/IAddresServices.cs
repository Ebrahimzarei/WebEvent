using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEventoo_DomainClasses.Services
{
  public  interface IAddresServices
    {
        Task<IEnumerable<Address>> GetAllAddressAsync();
        Task<Address> GetAddressAsync(int? id);
       
        Task<Address> AddAsync(Model.Address Address);
        Task<Address> UpdateAsync(Address Address);
        Task DeleteConfirmedAsync(int id);
    }
}
