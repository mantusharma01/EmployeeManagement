using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.CQRS.Queries;
using EmployeeManagement.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/Departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ISender _sender;

        public DepartmentsController(ISender sender)
        {
            _sender = sender;
        }



        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            var departments = await _sender.Send(new GetDepartmentsQuery());
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDepartments(int id)
        {
            var departments = await _sender.Send(new GetDepartmentByIdQuery(id));
            return Ok(departments);
        }

        [HttpPost]
        public async Task<ActionResult> AddDepartment([FromBody] Department department)
        {
            await _sender.Send(new AddDepartmentsCommand(department));
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, [FromBody] Department department)
        {
            await _sender.Send(new UpdateDepartmentsCommand(id, department));
            return StatusCode(203);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            await _sender.Send(new DeleteDepartmentCommand(id));
            return StatusCode(204);
        }
    }
}
