using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Queries
{
    public record GetDepartmentByIdQuery(int Id) : IRequest<Department>;

}