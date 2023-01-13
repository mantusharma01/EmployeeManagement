using EmployeeManagement.CQRS.Queries;
using EmployeeManagement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.CQRS.Handlers
{
    public class GetLocationByIdHandler : IRequestHandler<GetLocationByIdQuery, Location>
    {
        private readonly EmployeeManagementDBContext _context;

        public GetLocationByIdHandler(EmployeeManagementDBContext context)
        {
            _context = context;
        }

        public async Task<Location> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Locations.FindAsync(request.Id);
        }
    }
}
