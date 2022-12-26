using EmployeeManagement.CQRS.Queries;
using EmployeeManagement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.CQRS.Handlers
{
    public class GetLocationsHandler : IRequestHandler<GetLocationsQuery, IEnumerable<Location>>
    {
        private readonly sql6585767Context _context;

        public GetLocationsHandler(sql6585767Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Locations.ToListAsync();
        }
    }
}
