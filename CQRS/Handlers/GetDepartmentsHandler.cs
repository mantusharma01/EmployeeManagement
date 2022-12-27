using EmployeeManagement.CQRS.Queries;
using EmployeeManagement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.CQRS.Handlers
{
    public class GetDepartmentsHandler : IRequestHandler<GetDepartmentsQuery, IEnumerable<Department>>
    {
        private readonly sql6585767Context _context;

        public GetDepartmentsHandler(sql6585767Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Departments.ToListAsync();
        }
    }
}
