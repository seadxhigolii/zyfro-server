using System;

namespace Zyfro.Pro.Server.Common.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base("You have no permission for this action!")
        {
        }
    }
}
