
namespace Pms360.Application.Response;
public class Response : IResponse
{
    public List<string> Messages { get; set; } = new List<string>();
    public bool IsSuccessful { get; set; }

    #region Failure
    public static IResponse Fail()
    {
        return new Response()
        {
            IsSuccessful = false
        };
    }
    public static IResponse Fail(string Message)
    {
        return new Response()
        {
            IsSuccessful = false,
            Messages = new List<string> { Message }
        };
    }
    public static IResponse Fail(List<string> Message)
    {
        return new Response()
        {
            IsSuccessful = false,
            Messages = Message
        };
    }
    #endregion

    #region Success
    public static IResponse Success()
    {
        return new Response()
        {
            IsSuccessful = true
        };
    }
    public static IResponse Success(string Message)
    {
        return new Response()
        {
            IsSuccessful = true,
            Messages = new List<string> { Message }
        };
    }
    public static IResponse Success(List<string> Message)
    {
        return new Response()
        {
            IsSuccessful = true,
            Messages = Message
        };
    }
    #endregion
}

public class Response<T> : Response, IResponse<T>
{
    public T Data { get; set; } = default!;

    #region Failure
    public new static Response<T> Fail()
    {
        return new Response<T>()
        {
            IsSuccessful = false
        };
    }

    public new static Response<T> Fail(string message)
    {
        return new Response<T>()
        {
            IsSuccessful = false,
            Messages = [message]
        };
    }
    #endregion

    #region Success
    public new static Response<T> Success()
    {
        return new Response<T>()
        {
            IsSuccessful = true
        };
    }
    public new static Response<T> Success(string message)
    {
        return new Response<T>()
        {
            IsSuccessful = true,
            Messages = [message]
        };
    }

    public static Response<T> Success(T data)
    {
        return new Response<T>()
        {
            IsSuccessful = true,
            Data = data
        };
    }
    public static Response<T> Success(T data, string message)
    {
        return new Response<T>()
        {
            IsSuccessful = true,
            Data = data,
            Messages = [message]
        };
    }
    public static Response<T> Success(T data, List<string> message)
    {
        return new Response<T>()
        {
            IsSuccessful = true,
            Data = data,
            Messages = message
        };
    }
    #endregion
}
