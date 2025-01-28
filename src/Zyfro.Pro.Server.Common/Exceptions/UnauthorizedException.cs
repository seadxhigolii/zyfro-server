using System;

namespace Zyfro.Pro.Server.Common.Exceptions
{
    public class Unauthorized : Exception
    {
        public Unauthorized() : base("Unauthorized")
        {
        }
    }
}
