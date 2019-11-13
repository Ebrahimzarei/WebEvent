using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEventoo_DomainClasses.Services
{
    public interface IColorService
    {
        Task<IEnumerable<Colors>> GetAllColorsAsync();
        Task<List<Colors>> GetAllColorList();
        Task<Colors> GetColorsAsync(int? id);

        Task<Colors> AddAsync(Model.Colors Colors);
        Task<Colors> UpdateAsync(Colors Colors);
        Task DeleteConfirmedAsync(int id);
    }
}
