using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Commands
{


    public record UpdateDepartmentsCommand(int Id, Department Department) : IRequest;

}
