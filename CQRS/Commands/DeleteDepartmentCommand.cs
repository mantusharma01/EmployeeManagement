using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Commands
{

    public record DeleteDepartmentCommand(int Id) : IRequest;
   
}
