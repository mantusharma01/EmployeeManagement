using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class AddNewEmpHandler : IRequestHandler<AddNewEmpCommand,Unit>
    {
        private readonly sql6585767Context _context;

        public AddNewEmpHandler(sql6585767Context context)
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
