using System.Net;

namespace Leha.Core.BaseResponse;

public class Response<T>
{
    #region Fields
    public bool Succeeded { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
    public T? Data { get; set; }
    public object? Meta { get; set; } = null;
    #endregion

    #region Constructors
    public Response()
    {
    }
    public Response(T data, string message)
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }
    public Response(string message)
    {
        Succeeded = false;
        Message = message;
    }
    public Response(string message, bool succeeded)
    {
        Succeeded = succeeded;
        Message = message;
    }
    #endregion

    #region Handle Functions

    #endregion
}
