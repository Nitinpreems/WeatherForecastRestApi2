using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public string ErrorMessage { get; set; }
        public BadRequestException(string message)
        {
            ErrorMessage = message;
        }
    }
}
