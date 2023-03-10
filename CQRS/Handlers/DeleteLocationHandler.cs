using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class DeleteLocationHandler : IRequestHandler<DeleteLocationCommand, Unit>
    {
        private readonly EmployeeManagementDBContext _context;

        public DeleteLocationHandler(EmployeeManagementDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _context.Locations.FindAsync(request.Id);
            _context.Remove(location);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
