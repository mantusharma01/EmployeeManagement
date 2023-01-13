using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class AddLocationsHandler :IRequestHandler<AddLocationsCommand,Unit>
    {
        private readonly EmployeeManagementDBContext _context;

        public AddLocationsHandler(EmployeeManagementDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddLocationsCommand request, CancellationToken cancellationToken)
        {
            await _context.AddAsync(request.Location);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
