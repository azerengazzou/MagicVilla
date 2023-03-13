using System.Net;

namespace MagicVilla_Api.Models
{
    public class APIResponse 
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public List<string> Errors { get; set; }
        public Object Result { get; set; }
    }
}
