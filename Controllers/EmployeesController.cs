using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.CQRS.Queries;
using EmployeeManagement.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ISender _sender;
        public EmployeesController( ISender sender)
        {
            _sender=sender;
        }





        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            var Employees = await _sender.Send(new GetEmpsByIdQuery(id));
            return Ok(Employees);
        }

        [HttpPost]
        public async Task<ActionResult> PostEmployee([FromBody] Employee employee)
        {
            await _sender.Send(new AddNewEmpCommand(employee));
            return StatusCode(200);
        }



    }
}
