using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactOpenTable.Context;
using ReactOpenTable.Services;
using ReactOpenTable.Models;
using ReactOpenTable.Extensions;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactOpenTable.Controllers
{
    [Route("api/Interaction")]
    public class InteractionController : ControllerBase
    {
        public DbAppContext _context { get; }

        public InteractionController(DbAppContext context)
        {
            _context = context;
        }
        // GET api/Interaction/5
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string name, DateTime? beginDate, DateTime? endDate, int? id = null)
        {
            if ((string.IsNullOrEmpty(name) || !beginDate.HasValue || !endDate.HasValue) && !id.HasValue)
            {
                return new BadRequestObjectResult("Not enough values supplied.");
            }
            await _context.Connection.OpenAsync();
            var query = new InteractionService(_context);

            if (id.HasValue)
            {
                var result = await query.GetSingleAsync(id.Value);
                if (result is null)
                    return new NotFoundResult();
                return new OkObjectResult(result);
            }
            else
            {
                var result = await query.GetAsync(name, beginDate.Value, endDate.Value);
                if (result is null)
                    return new NotFoundResult();
                return new OkObjectResult(result);
            }
        }


        // POST api/Interaction
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InteractionDto body)
        {
            await _context.Connection.OpenAsync();
            var obj = new InteractionService
            {
                Name_input = body?.Name_input,
                Date_input = body?.Date_input,
                Num_assisted = (body?.Num_assisted).ToInt(),
                Location = body?.Location,
                Reject_assistance = body?.Reject_assistance,
                Other = body?.Other.ToInt(),
                Emergency = body?.Emergency.ToInt(),
                Launchpad = body?.Launchpad.ToInt(),
                Mission = body?.Mission.ToInt(),
                Staging = body?.Staging.ToInt(),
                Other_comment = body?.Other_comment
            };

            obj._context = _context;
            await obj.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody]InteractionDto body)
        {
            var obj = new InteractionService
            {
                Name_input = body?.Name_input,
                Date_input = body?.Date_input,
                Num_assisted = body?.Num_assisted.ToInt(),
                Location = body?.Location,
                Reject_assistance = body?.Reject_assistance,
                Other = body?.Other.ToInt(),
                Emergency = body?.Emergency.ToInt(),
                Launchpad = body?.Launchpad.ToInt(),
                Mission = body?.Mission.ToInt(),
                Staging = body?.Staging.ToInt(),
                Other_comment = body?.Other_comment
            };

            await _context.Connection.OpenAsync();
            var query = new InteractionService(_context);
            var result = await query.GetSingleAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.Id = obj.Id;
            result.Name_input = obj.Name_input;
            result.Date_input = obj.Date_input;
            result.Num_assisted = obj.Num_assisted;
            result.Location = obj.Location;

            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _context.Connection.OpenAsync();
            var query = new InteractionService(_context);
            var result = await query.GetSingleAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }
    }
}
