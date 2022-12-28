using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class UpdateLocationsHandler : IRequestHandler<UpdateLocationsCommand, Unit>
    {
        private readonly EmployeeManagementDBContext _context;

        public UpdateLocationsHandler(EmployeeManagementDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateLocationsCommand request, CancellationToken cancellationToken)
        {
            var tempLocation = await _context.Locations.FindAsync(request.Id);
            tempLocation.LocationData = request.Location.LocationData;
            _context.Update(tempLocation);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
