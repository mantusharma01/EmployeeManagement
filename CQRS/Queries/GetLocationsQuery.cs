using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Queries
{
    public record GetLocationsQuery:IRequest<IEnumerable<Location>>;
}
