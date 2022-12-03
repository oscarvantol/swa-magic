using ExampleApi.Repositories;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FunctionsApiApp;

public class MembersFunction
{
    private readonly MembersRepo _membersRepo;
    private readonly ILogger _logger;

    public MembersFunction(MembersRepo membersRepo, ILoggerFactory loggerFactory)
    {
        _membersRepo = membersRepo;
        _logger = loggerFactory.CreateLogger<MembersFunction>();
    }

    [Function(nameof(GetMembers))]
    public async Task<HttpResponseData> GetMembers([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Members")] HttpRequestData req)
    {
        _logger.LogInformation("Returning members from repo");
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(_membersRepo.GetMembers());
        return response;
    }
}
