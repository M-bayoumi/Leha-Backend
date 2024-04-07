using Leha.Core.Resources;
using Microsoft.Extensions.Localization;

namespace Leha.Core.BaseResponse;

public class ResponseHandler
{
    #region Fields
    private readonly IStringLocalizer<SharedResources> _localizer;

    #endregion

    #region Constructors

    public ResponseHandler(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
    }
    #endregion

    #region Handle Functions
    public Response<T> Success<T>(T? entity, string? message = null, object? Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = string.IsNullOrEmpty(message) ? _localizer[SharedResourcesKeys.Success] : message,
            Meta = Meta
        };
    }
    public Response<T> Created<T>(T entity, string? message = null, object? Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.Created,
            Succeeded = true,
            Message = string.IsNullOrEmpty(message) ? _localizer[SharedResourcesKeys.Created] : message,
            Meta = Meta
        };
    }
    public Response<T> NotFound<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            Succeeded = false,
            Message = string.IsNullOrEmpty(message) ? _localizer[SharedResourcesKeys.NotFound] : message,
        };
    }

    public Response<T> BadRequest<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = string.IsNullOrEmpty(message) ? _localizer[SharedResourcesKeys.BadRequest] : message,
        };
    }
    public Response<T> Deleted<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = string.IsNullOrEmpty(message) ? _localizer[SharedResourcesKeys.Deleted] : message,
        };
    }

    public Response<T> Unauthorized<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            Succeeded = true,
            Message = string.IsNullOrEmpty(message) ? _localizer[SharedResourcesKeys.UnAuthorized] : message,
        };
    }

    public Response<T> UnprocessableEntity<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
            Succeeded = false,
            Message = string.IsNullOrEmpty(message) ? _localizer[SharedResourcesKeys.UnProcessable] : message,
        };
    }
    #endregion
}