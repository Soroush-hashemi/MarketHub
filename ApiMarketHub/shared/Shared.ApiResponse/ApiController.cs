using Microsoft.AspNetCore.Mvc;
using Shared.ApiResponse.Links;
using Shared.Application;
using System.Net;

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

    protected ApiResult<TData?> CommandResult<TData>(OperationResult<TData> operationResult, HttpStatusCode httpStatus, string UrlPath)
    {
        bool isSuccess = operationResult.Status == OperationResultStatus.Success;
        if (isSuccess is true)
        {
            HttpContext.Response.StatusCode = (int)httpStatus;
        }
        return new ApiResult<TData?>
        {
            IsSuccess = isSuccess,
            Data = isSuccess ? operationResult.Data : default,
            Links = LinkGenerator.AddLink<TData>(operationResult.Data, UrlPath),
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