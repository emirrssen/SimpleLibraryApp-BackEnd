namespace SimpleLibraryApp.Core.Response;

public class BaseResponse
{
    public BaseResponse(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public bool IsSuccess { get; set; }
    public string Message { get; set; }

}

public class GenericDataResponse<T> : BaseResponse
{
    public GenericDataResponse(T data, bool isSuccess, string message) : base(isSuccess, message)
    {
        Data = data;
    }

    public T Data { get; set; }
}
