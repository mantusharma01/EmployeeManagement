using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.CQRS.Handlers
{
    public class AddDepartmentsHandler : IRequestHandler<AddDepartmentsCommand, Unit>
    {
        private readonly EmployeeManagementDBContext _context;

        public AddDepartmentsHandler(EmployeeManagementDBContext context)
        {
            _context = context;
        }

       public async Task<Unit> Handle(AddDepartmentsCommand request, CancellationToken cancellationToken)
        {

            await _context.AddAsync(request.Department);
            await _context.SaveChangesAsync();
            return Unit.Value;  
           

        }
    }
}



