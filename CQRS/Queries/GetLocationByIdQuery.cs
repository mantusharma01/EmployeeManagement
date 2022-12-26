using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Queries
{
    public record GetLocationByIdQuery(int Id):IRequest<Location>;
    
}
