using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Queries
{
    public record GetEmpsByIdQuery(int Id ):IRequest<Employee>;
   
}
