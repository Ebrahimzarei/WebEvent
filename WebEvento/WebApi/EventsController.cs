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
    //[Route("api/[controller]")]
    [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    [ApiController]
    public class EventsController : ControllerBase
    {
        IEventServices Event;
        public EventsController(IEventServices IEvent)
        {
            Event = IEvent;
        }
        [HttpPost("/api/test")]
        public string test()
        {
            return "rest;";
        }
        // GET: api/<controller>
        [HttpPost("/api/GetEventsItems")]
        public async Task<ActionResult<List<Event>>> GetEventsItems()
        {
            var GetEvents= await Event.GetAllEventListAsync();
           
            foreach (var item in GetEvents)
            {
               
            }
            //return await _context.TodoItems.ToListAsync();
            return await Event.GetAllEventListAsync();
        }

        // GET api/<controller>/5
        [HttpPost("/api/FindEventsItem/{id}")]
      
        public async Task<ActionResult<Event>> FindEventsItem(int id)
        {
            var eventItem = await Event.GetEventAsync(id);
           
            if (eventItem == null)
            {
                return NotFound();
            }

            return eventItem;
        }


        [HttpPost("/api/PostTodoItem")]
        public async Task<ActionResult<Event>> PostTodoItem(Event item)
        {
            await Event.AddAsync(item);

            return CreatedAtAction(nameof(Event), new { id = item.Id }, item);
        }

        // PUT api/<controller>/5
        //[HttpPut("{id}")]
        [HttpPost("/api/PutEventItem/{id}")]
        public async Task<IActionResult> PutEventItem(long id, Event item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            await Event.UpdateAsync(item);
            return NoContent();
        }

        // DELETE api/<controller>/5
       // [HttpDelete("{id}")]
        [HttpDelete("/api/DeleteEventItem/{id}")]
        public async Task<IActionResult> DeleteEventItem(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await Event.DeleteConfirmedAsync(id);
            return NoContent();
        }
    }
}
