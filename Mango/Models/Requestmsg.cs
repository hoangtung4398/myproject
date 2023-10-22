using static Mango.Web.Utility.SD;

namespace Mango.Web.Models
{
    public class Requestmsg
    {
        public ApiType ApiType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
