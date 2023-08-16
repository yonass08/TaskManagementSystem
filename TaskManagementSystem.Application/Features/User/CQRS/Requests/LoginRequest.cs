using MediatR;
using TaskManagementSystem.Application.Features.User.DTO;

namespace TaskManagementSystem.Application.Features.User.CQRS.Requests;

public class LoginRequest: IRequest<LoginResponse>
{
    public LoginDto LoginDto {get; set;}
    
}




