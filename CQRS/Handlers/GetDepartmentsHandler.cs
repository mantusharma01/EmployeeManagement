using EmployeeManagement.CQRS.Queries;
using EmployeeManagement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.CQRS.Handlers
{
    public class GetDepartmentsHandler : IRequestHandler<GetDepartmentsQuery, IEnumerable<Department>>
    {
        private readonly EmployeeManagementDBContext _context;

        public GetDepartmentsHandler(EmployeeManagementDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Departments.ToListAsync();
        }
    }
}
