namespace Pms360.Application.Response;
public interface IResponse
{
    public List<string> Messages { get; set; }
    public bool IsSuccessful { get; set; }
}
public interface IResponse<out T>: IResponse
{
    public T Data { get; }
}
