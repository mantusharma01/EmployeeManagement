using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class AddNewEmpHandler : IRequestHandler<AddNewEmpCommand,Unit>
    {
        private readonly EmployeeManagementDBContext _context;

        public AddNewEmpHandler(EmployeeManagementDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddNewEmpCommand request, CancellationToken cancellationToken)
        {
            await _context.AddAsync(request.Employee);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
