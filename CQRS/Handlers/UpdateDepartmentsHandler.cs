using EmployeeManagement.CQRS.Commands;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class UpdateDepartmentsHandler : IRequestHandler<UpdateDepartmentsCommand, Unit>
    {
        private readonly EmployeeManagementDBContext _context;

        public UpdateDepartmentsHandler(EmployeeManagementDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateDepartmentsCommand request, CancellationToken cancellationToken)
        {
            var tempDepartment = await _context.Departments.FindAsync(request.Id);
            tempDepartment.DepartmentName = request.Department.DepartmentName;
            _context.Update(tempDepartment);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
