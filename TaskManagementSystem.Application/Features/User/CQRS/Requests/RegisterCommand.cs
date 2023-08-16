using MediatR;
using TaskManagementSystem.Application.Features.User.DTO;

namespace TaskManagementSystem.Application.Features.User.CQRS.Requests;

public class RegisterCommand: IRequest<RegisterResponse>
{
    public RegisterDto RegisterDto {get; set;}
    
}
