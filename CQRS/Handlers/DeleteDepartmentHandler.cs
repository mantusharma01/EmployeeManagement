using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly sql6585767Context _context;

        public DeleteDepartmentHandler(sql6585767Context context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var Department = await _context.Departments.FindAsync(request.Id);
            _context.Remove(Department);
            await _context.SaveChangesAsync();


            return Unit.Value;
        }
    }
}
