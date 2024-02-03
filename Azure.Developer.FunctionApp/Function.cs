using CDW.Developer.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace CDW.Developer.FunctionApp;

public class Function
{
    private readonly IBankHolidayService _bankHolidayService;

    public Function(IBankHolidayService bankHolidayService)
    {
        _bankHolidayService = bankHolidayService;
    }

    [Function(nameof(GetBankHolidays))]
    public async Task<IActionResult> GetBankHolidays(
         [HttpTrigger(AuthorizationLevel.Function, "get", Route = "government/holidays")] HttpRequestData req
        )
    {
        //API Link: GET http://localhost:7200/api/government/holidays, you may need to change the port
        //If I had time I would add ckecking for authentication and swagger configuration

        var response = await _bankHolidayService.GetBankHolidaysAsync();

        return ResponseHelper.ActionResultFromServiceResponse(response);
    }
}
