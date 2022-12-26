using EmployeeManagement.CQRS.Queries;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Handlers
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, Department>
    {
        private readonly sql6585767Context _context;

        public GetDepartmentByIdHandler(sql6585767Context context)
        {
            _context = context;
        }

        public async Task<Department> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Departments.FindAsync(request.Id);
        }
    }
}


