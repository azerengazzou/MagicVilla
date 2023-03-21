using System.Net;

namespace MagicVilla_Api.Models
{
    public class APIResponse 
    {
        public APIResponse()
        {
            ErrorMessage = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessage { get; set; }
        public List<string> Errors { get; set; }
        public Object Result { get; set; }
    }
}
