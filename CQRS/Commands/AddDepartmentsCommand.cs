using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Commands
{
   
        public record AddDepartmentsCommand(Department Department) : IRequest;
    
}
