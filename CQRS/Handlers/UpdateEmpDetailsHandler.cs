using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class UpdateEmpDetailsHandler : IRequestHandler<UpdateEmpDetailsCommand, Unit>
    {
        private readonly EmployeeManagementDBContext _context;

        public UpdateEmpDetailsHandler(EmployeeManagementDBContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateEmpDetailsCommand request, CancellationToken cancellationToken)
        {
            var emp = await _context.Employees.FindAsync(request.Id);
            emp.FirstName = request.Employee.FirstName;
            emp.LastName = request.Employee.LastName;
            emp.PhoneNumber = request.Employee.PhoneNumber;
            emp.Email = request.Employee.Email;
            emp.DepartmentId = request.Employee.DepartmentId;
            emp.LocationId = request.Employee.LocationId;

            _context.Update(emp);
            await _context.SaveChangesAsync();
            return Unit.Value;

        }
    }
}
