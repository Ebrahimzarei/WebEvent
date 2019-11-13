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
    [Route("api/[controller]")]
    public class ColorController : Controller
    {
        IColorService Color;
        public ColorController(IColorService IColor)
        {
            Color = IColor;
        }
        // GET: api/<controller>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Colors>>> GetEventsItems()
        {
            //return await _context.TodoItems.ToListAsync();
            return await Color.GetAllColorList();
        }

 
    }
}
