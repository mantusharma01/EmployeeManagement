using MediatR;

namespace EmployeeManagement.CQRS.Commands
{
    public record DeleteLocationCommand(int Id):IRequest;
}
