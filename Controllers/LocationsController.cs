using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.CQRS.Queries;
using EmployeeManagement.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/Locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ISender _sender;

        public LocationsController(ISender sender)
        {
            _sender = sender;
        }

        

        [HttpGet]
        public async Task<ActionResult> GetLocations()
        {
            var locations = await _sender.Send(new GetLocationsQuery());
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetLocations(int id)
        {
            var locations=await _sender.Send(new GetLocationByIdQuery(id));
            return Ok(locations);
        }

        [HttpPost]
        public async Task<ActionResult> AddLocation([FromBody]Location location)
        {
            await _sender.Send(new AddLocationsCommand(location));
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLocation(int id, [FromBody]Location location)
        {
            await _sender.Send(new UpdateLocationsCommand(id, location));
            return StatusCode(203);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLocation(int id)
        {
            await _sender.Send(new DeleteLocationCommand(id));
            return StatusCode(204);
        }
    }
}
