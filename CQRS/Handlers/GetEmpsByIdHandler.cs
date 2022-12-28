using EmployeeManagement.CQRS.Queries;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class GetEmpsByIdHandler : IRequestHandler<GetEmpsByIdQuery,Employee>
    {
        private readonly EmployeeManagementDBContext _context;

        public GetEmpsByIdHandler(EmployeeManagementDBContext context)
        {
            _context = context;
        }
        public async Task<Employee> Handle(GetEmpsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees.FindAsync(request.Id);
        }
    }
}
