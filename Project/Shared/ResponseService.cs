using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared
{
    public class ResponseService<T>
    {
        public ResponseService()
        {
            this.Success = 0;
            this.HttpResponseMessage = new HttpResponseMessage();
            this.Data = Data;
        }

        public ResponseService(int Success, string Message, T Data)
        {
            this.Success = Success;
            this.Message = Message;
            this.Data = Data;
        }
        public ResponseService(int Success, string Message, T Data, HttpResponseMessage HttpResponseMessage)
        {
            this.Success = Success;
            this.Message = Message;
            this.Data = Data;
            this.HttpResponseMessage = HttpResponseMessage;
        }
        public ResponseService(int Success, string Message, T Data, System.Net.HttpStatusCode httpStatusCode)
        {
            this.Success = Success;
            this.Message = Message;
            this.Data = Data;
            this.HttpResponseMessage = new HttpResponseMessage();
            this.HttpResponseMessage.StatusCode = httpStatusCode;
        }

        public ResponseService(int Success, string Message, T[] Data, HttpResponseMessage HttpResponseMessage)
        {
            this.Success = Success;
            this.Message = Message;
            this.HttpResponseMessage = HttpResponseMessage;
        }

        public int Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}
