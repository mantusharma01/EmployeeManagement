using EmployeeManagement.CQRS.Queries;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class GetEmpsByIdHandler : IRequestHandler<GetEmpsByIdQuery,Employee>
    {
        private readonly sql6585767Context _context;

        public GetEmpsByIdHandler(sql6585767Context context)
        {
            _context = context;
        }
        public async Task<Employee> Handle(GetEmpsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees.FindAsync(request.Id);
        }
    }
}
