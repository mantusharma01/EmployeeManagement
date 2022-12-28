using EmployeeManagement.CQRS.Queries;
using EmployeeManagement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Runtime.InteropServices;

namespace EmployeeManagement.CQRS.Handlers
{
    public class GetEmpsHandler : IRequestHandler<GetEmpsQuery, IEnumerable<Employee>>
    {
        private readonly EmployeeManagementDBContext _context;

        public GetEmpsHandler(EmployeeManagementDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> Handle(GetEmpsQuery request, CancellationToken cancellationToken)
        {

            return await _context.Employees.ToListAsync();
        }
    
    }
}
