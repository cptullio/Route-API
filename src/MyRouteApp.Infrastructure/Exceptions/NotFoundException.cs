using System;
using System.Collections.Generic;
using System.Text;

namespace MyRouteApp.Infrastructure.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException() : base()
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
