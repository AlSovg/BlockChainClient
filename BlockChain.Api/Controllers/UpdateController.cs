using System.Text.Json;
using BlockChain.Api.Repositories;
using BlockChain.Api.Utils;
using BlockChain.Domain.Context;
using BlockChain.Domain.Models.DataBase;
using BlockChain.Domain.Models.Request;
using BlockChain.Domain.Models.Request.PyData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlockChain.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UpdateController
{
    private readonly ILogger<UpdateController> _logger;
    private readonly UpdateRepository _updateRepository;

    public UpdateController(ILogger<UpdateController> logger, UpdateRepository updateRepository)
    {
        this._logger = logger;
        this._updateRepository = updateRepository;
    }
    
    [HttpGet]
    [Route("GetData")]
    public async Task<ResponseModel?> GetApiData()
    {
        var isFileRewrote = PythonActions.ReplaceUserData("./Python/start.py", new AuthData());
        if (!isFileRewrote)
        {
            _logger.LogError("Ошибка перезаписи файла");
        }
        var getAuthData = await PythonActions.ExecutePythonScriptAsync() ?? new GetAuthData();
        var postAuthData = new PostAuthData(getAuthData);
        var response = await _updateRepository.GetData(JsonSerializer.Serialize(postAuthData));
        if (response!.Status)
        {
            return response;
        }
        _logger.LogError("Ошибка запроса");
        return response;
    }
    
    [HttpGet]
    [Route("CheckData")]
    public async Task<CompareModel?> GetNewDataAsync()
    {
        var apiData = await GetApiData();
        var result = await _updateRepository.CompareData(apiData);
        return result;
    }
}

