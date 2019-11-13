using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebEvento.WebApi
{
   // [Route("api/[controller]")]
    [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    [ApiController]
    public class InformationController : ControllerBase
    {
        IInformationService InformatibServices;
        public InformationController(IInformationService Information)
        {
            InformatibServices = Information;
        }
        [HttpPost("/api/GetInformationItems")]
        public async Task<ActionResult<List<Information>>> GetInformationItems()
        {
            var Item= await InformatibServices.GetAllInformationListAsync();

            //return await _context.TodoItems.ToListAsync();
            return await InformatibServices.GetAllInformationListAsync();
        }

        

 

        

        

        
    }
}
