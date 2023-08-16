using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.User.CQRS.Requests;
using TaskManagementSystem.Application.Features.User.DTO;

namespace TaskManagementSystem.Application.Features.User.CQRS.Handlers;


public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var User = await _unitOfWork.UserRepository.GetByEmail(request.RegisterDto.Email);
        if (User != null)
            throw new BadRequestException("Email already exists");

        var user = new Domain.User
        {
            UserName = request.RegisterDto.UserName,
            Email = request.RegisterDto.Email,
            Password = request.RegisterDto.Password
        };


        await _unitOfWork.UserRepository.Add(user);
        if (await _unitOfWork.Save() < 0)
            throw new ActionNotPerfomedException("user not created");

        var response = new RegisterResponse
        {
            UserName = user.UserName,
            Email = user.Email,
            Id = user.Id
        };

        return response;
    }

    public string GenerateToken(){
        return "";
    }

}