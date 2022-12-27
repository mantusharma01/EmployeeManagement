using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Queries
{
    public record GetDepartmentsQuery : IRequest<IEnumerable<Department>>;
}
