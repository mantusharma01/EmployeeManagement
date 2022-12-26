//using EmployeeManagement.Models;
//using MediatR;
//using Microsoft.EntityFrameworkCore;

//namespace EmployeeManagement.CQRS.Handlers
//{
//    public class GetEmpsHandler : IRequestHandler<GetEmpsHandler, IEnumerable<Employee>>
//    {

//        private readonly sql6585767Context _context;

//        public GetEmpsHandler(sql6585767Context context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Employee>> Handle(GetEmpsHandler request, CancellationToken cancellationToken)
//        {
//            return await _context.Employees.ToListAsync();
//        }
//    }
//}
