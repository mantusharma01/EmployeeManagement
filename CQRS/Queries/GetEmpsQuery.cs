using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Queries
{
    public record GetEmpsQuery: IRequest<IEnumerable<Employee>>;
   
}
