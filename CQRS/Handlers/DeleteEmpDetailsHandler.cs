using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class DeleteEmpDetailsHandler : IRequestHandler<DeleteEmpCommand, Unit>
    {

        private readonly sql6585767Context _context;

        public DeleteEmpDetailsHandler(sql6585767Context context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteEmpCommand request, CancellationToken cancellationToken)
        {
            var emp = await _context.Employees.FindAsync(request.Id);
            _context.Remove(emp);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
