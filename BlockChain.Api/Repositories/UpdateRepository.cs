using System.Text;
using System.Text.Json;
using BlockChain.Api.Utils;
using BlockChain.Domain.Context;
using BlockChain.Domain.Models.DataBase;
using BlockChain.Domain.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace BlockChain.Api.Repositories;

public class UpdateRepository
{
    private const string BaseUrl = "https://b1.ahmetshin.com/restapi/";
    private readonly HttpClient _httpClient;
    protected readonly ApplicationContext Context;

    public UpdateRepository(HttpClient httpClient, ApplicationContext context)
    {
        _httpClient = httpClient;
        Context = context;
        _httpClient.DefaultRequestHeaders.Add("mode", "no-cors");
    }

    public async Task<ResponseModel?> GetData(string? jsonData = null)
    {
        const string url = $"{BaseUrl}get_chains";
        using var content = new StringContent(jsonData!, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);
        var responseStream = await response.Content.ReadAsStreamAsync();
        var responseString = await response.Content.ReadAsStringAsync();
        var responseContent = await JsonSerializer.DeserializeAsync<ResponseModel>(responseStream);
        return responseContent;
    }

    public async Task<CompareModel> CompareData(ResponseModel? responseModel)
    {
        var response = new CompareModel();
        var apiUsers = responseModel?.ActiveBlock.Users.OrderByDescending(u => u.UserId).ToList();
        var dbUsers = await Context.Users
            .AsNoTracking()
            .Distinct()
            .OrderByDescending(u => u.UserId)
            .Select(x => new UserViewModel(x))
            .ToListAsync();


        var newUsers = apiUsers?.Except(dbUsers, new Comparer.UserComparer()).ToList();

        if (newUsers!.Any())
        {
            await Context.Users.AddRangeAsync(newUsers!.Select(user => new User(user)));
            await Context.SaveChangesAsync();
            response = new SuccessCompareModel();
        }

        var apiBlocks = responseModel?.ActiveBlock.Blocks.OrderByDescending(b => b.BlockId).ToList();

        var dbBlocks = await Context.Blocks
            .AsNoTracking()
            .Distinct()
            .OrderByDescending(b => b.BlockId)
            .Select(x => new BlockViewModel(x))
            .ToListAsync();

        var newBlocks = apiBlocks?.Except(dbBlocks, new Comparer.BlockComparer()).ToList();

        if (newBlocks!.Any())
        {
            await Context.Blocks.AddRangeAsync(newBlocks!.Select(block => new Block(block)));
            await Context.SaveChangesAsync();
            response = new SuccessCompareModel();
        }

        var actionList = new List<ActionViewModel>();
        apiBlocks.ForEach(block =>
        {
            if (block != null && block.Actions != null)
            {
                var hashServices = block.Actions;
                hashServices.ForEach(hashServices =>
                {
                    if (hashServices.ActionsViewModel != null)
                    {
                        var action = hashServices.ActionsViewModel;
                        actionList.Add(action);
                    }
                });
            }
        });
        

        return response;
    }
}