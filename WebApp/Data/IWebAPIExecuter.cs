
namespace WebApp.Data
{
    public interface IWebAPIExecuter
    {
        Task<T?> InvokeGet<T>(string relativeUrl);
    }
}