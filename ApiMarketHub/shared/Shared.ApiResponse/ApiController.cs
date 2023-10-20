using Microsoft.AspNetCore.Mvc;
using Shared.Application;
using System.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shared.ApiResponse;

[Route("api/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    protected ApiResult CommandResult(OperationResult operationResult)
    {
        return new ApiResult()
        {
            IsSuccess = operationResult.Status == OperationResultStatus.Success,
            MetaData = new()
            {
                Message = operationResult.Message,
                AppStatusCode = operationResult.Status.Map()
            }
        };
    }

    protected ApiResult<TData?> CommandResult<TData>(OperationResult<TData> operationResult, HttpStatusCode httpStatus, string Url = null)
    {
        bool isSuccess = operationResult.Status == OperationResultStatus.Success;
        if (isSuccess is true)
        {
            HttpContext.Response.StatusCode = (int)httpStatus;
            if (!string.IsNullOrWhiteSpace(Url))
            {
                HttpContext.Response.Headers.Add("location", Url);
            }
        }
        return new ApiResult<TData?>
        {
            IsSuccess = isSuccess,
            Data = isSuccess ? operationResult.Data : default,
            MetaData = new()
            {
                Message = operationResult.Message,
                AppStatusCode = operationResult.Status.Map()
            }
        };
    }

    protected ApiResult<TData> QueryResult<TData>(TData result)
    {
        return new ApiResult<TData>()
        {
            IsSuccess = true,
            Data = result,
            MetaData = new()
            {
                Message = "عملیات با موفقیت انجام شد",
                AppStatusCode = AppStatusCode.Success
            }
        };
    }
}



public static class AppStatusCodeMapper
{
    public static AppStatusCode Map(this OperationResultStatus resultStatus)
    {
        switch (resultStatus)
        {
            case OperationResultStatus.Success:
                return AppStatusCode.Success;

            case OperationResultStatus.NotFound:
                return AppStatusCode.NotFound;

            case OperationResultStatus.Error:
                return AppStatusCode.LogicError;
        }
        return AppStatusCode.LogicError;
    }
}