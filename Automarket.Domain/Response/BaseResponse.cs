using Automarket.Domain.Enum;

namespace Automarket.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        //св-во содержит название ошибки, если она случится
        public string Description { get; set; }

        //содержит код ошибки
        public StatusCode StatusCode { get; set; }

        //для хранения результата запроса 
        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        string Description { get; }
        StatusCode StatusCode { get; }
        T Data { get; }
    }
}
