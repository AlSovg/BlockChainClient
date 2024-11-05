using System.Text.Json;
using BlockChain.Api.Repositories;
using BlockChain.Api.Utils;
using BlockChain.Domain.Context;
using BlockChain.Domain.Models.DataBase;
using BlockChain.Domain.Models.Request;
using BlockChain.Domain.Models.Request.PyData;
using BlockChain.Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlockChain.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController
{
    private readonly ILogger<AuthController> logger;
    private readonly AuthRepository authRepository;
    protected readonly ApplicationContext context;

    public AuthController(ILogger<AuthController> logger, AuthRepository authRepository, ApplicationContext context)
    {
        this.logger = logger;
        this.authRepository = authRepository;
        this.context = context;
    }
    
    [HttpGet]
    [Route("GetData")]
    public async Task<ResponseModel?> GetApiData()
    {
        var isFileRewrote = PythonActions.ReplaceUserData("./Python/start.py", new AuthData());
        if (!isFileRewrote) Console.WriteLine("AuthError");
        var userInfo = await PythonActions.ExecutePythonScriptAsync();
        var userInfo1 = new PostAuthData()
        {
            username = userInfo.username ?? "",
            password = userInfo.password ?? "",
            hach_version_file = userInfo.hach_version_file,
            user_hash = userInfo.user_hash
        };
        var response = await authRepository.GetData(JsonSerializer.Serialize(userInfo1));
        return response;
    }
    
    [HttpGet]
    [Route("CheckData")]
    public async Task<bool> GetNewDataAsync()
    {
        // Получаем текущую версию или метку времени с API
        var apiVersion = await GetApiData();
        var users = apiVersion.ActiveBlock.Users.OrderByDescending( u => u.UserId).ToList();

        var dbUsers = await context.Users
            .AsNoTracking()
            .Distinct()
            .OrderByDescending(u => u.UserId)
            .Select(x => new UserViewModel(x))
            .ToListAsync();
            

        
        var newUsers = users.Except(dbUsers, new Comparer.UserComparer()).ToList();

        if (newUsers.Any())
        {
            await context.Users.AddRangeAsync(newUsers.Select(user => new User(user)));
            await context.SaveChangesAsync();
        }

        return true;
    }
}

