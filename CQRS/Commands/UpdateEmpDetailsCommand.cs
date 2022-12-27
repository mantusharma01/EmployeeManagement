using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Commands
{
    public record UpdateEmpDetailsCommand(int Id, Employee Employee): IRequest;
   
}
