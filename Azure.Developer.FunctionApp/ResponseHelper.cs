using CDW.Developer.Service.Response;
using Microsoft.AspNetCore.Mvc;

namespace CDW.Developer.FunctionApp
{
    public static class ResponseHelper
    {
        public static IActionResult ActionResultFromServiceResponse<T>(ServiceResponse<T> response)
        {
            return new OkObjectResult(response.Result);
        }
    }
}
