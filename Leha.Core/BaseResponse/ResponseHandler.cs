namespace Leha.Core.BaseResponse;

public class ResponseHandler
{
    #region Fields

    #endregion

    #region Constructors
    public ResponseHandler()
    {
    }
    #endregion

    #region Handle Functions
    public Response<T> Success<T>(T entity, string? message = null, object? Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = string.IsNullOrEmpty(message) ? "Data found successfully" : message,
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
            Message = string.IsNullOrEmpty(message) ? "Created Successfully" : message,
            Meta = Meta
        };
    }
    public Response<T> NotFound<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            Succeeded = false,
            Message = string.IsNullOrEmpty(message) ? "NotFound" : message
        };
    }

    public Response<T> BadRequest<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = string.IsNullOrEmpty(message) ? "Bad Request" : message
        };
    }
    public Response<T> Deleted<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = string.IsNullOrEmpty(message) ? "Deleted Successfully" : message
        };
    }

    public Response<T> Unauthorized<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            Succeeded = true,
            Message = string.IsNullOrEmpty(message) ? "UnAuthorized" : message
        };
    }

    public Response<T> UnprocessableEntity<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
            Succeeded = false,
            Message = string.IsNullOrEmpty(message) ? "Unprocessable Entity" : message
        };
    }
    #endregion
}