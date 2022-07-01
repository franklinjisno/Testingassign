using System.Net;

namespace ProductsAPI.Models
{
    public class BusinessResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }
    }
}
