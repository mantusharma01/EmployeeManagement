using MediatR;

namespace EmployeeManagement.CQRS.Commands
{
    public record DeleteEmpCommand(int Id ): IRequest;
  
}
