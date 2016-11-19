using System;

namespace Fczrk.Common.Exceptions
{
    public class ForbiddenException : ApplicationException
    {
        public ForbiddenException(string message) : base(message)
        {

        }
    }
}
