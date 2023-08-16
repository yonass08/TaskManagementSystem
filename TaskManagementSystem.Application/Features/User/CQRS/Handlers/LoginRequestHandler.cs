using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.User.CQRS.Requests;
using TaskManagementSystem.Application.Features.User.DTO;

namespace TaskManagementSystem.Application.Features.User.CQRS.Handlers;


public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LoginRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var User = await _unitOfWork.UserRepository.GetByEmail(request.LoginDto.Email);
        if (User == null)
            throw new NotFoundException(nameof(Domain.Task), request.LoginDto.Email);

        if (User.Password != request.LoginDto.Password)
            throw new UnauthorizedException($"Incorrect password");

        var response = new LoginResponse
        {
            UserName = User.UserName,
            Email = User.Email,
            Token = GenerateToken()
        };

        return response;
    }

    public string GenerateToken(){
        return "";
    }
}