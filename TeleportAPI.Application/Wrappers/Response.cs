using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeleportAPI.Application.Wrappers
{
    public class Response<T> where T : class
    {
        public Response()
        {
            Errors = new List<string>();
        }

        public bool IsSucceeded { get; } = true;
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }

    public class Response
    {
        public Response()
        {
            Errors = new List<string>();
        }

        public bool IsSucceeded { get; set; } = true;
        public List<string> Errors { get; set; }
    }
}
