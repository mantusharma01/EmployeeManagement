using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly EmployeeManagementDBContext _context;

        public DeleteDepartmentHandler(EmployeeManagementDBContext context)
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
