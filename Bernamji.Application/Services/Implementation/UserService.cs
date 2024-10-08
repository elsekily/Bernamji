using bernamji.Core.Entities;
using Bernamji.Application.Services.Core;
using Bernamji.DataAccess.Repositories.Core;
using Bernamji.DTOs.DTOs;
using Bernamji.Shared.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bernamji.Application.Services.Implementation;
public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly ISecurityService securityService;

    public UserService(IUserRepository userRepository,ISecurityService securityService)
    {
        this.userRepository = userRepository;
        this.securityService = securityService;
    }

    public async Task<LoginResponseResource> CheckUserCredentials(UserResource userResource)
    {
        var user = await userRepository.GetByUserNameAsync(userResource.UserName);

        var result = new LoginResponseResource();

        if (user == null || !securityService.CheckPassword(userResource.Password,user.Password)) 
        {
            result.Message = "User Name Or Password Is Incorrect!";
            return result;
        }

        result.IsSuccess = true;
        result.Message = "Login Successful";
        result.UserName = user.UserName;
        return result;  
    }
}