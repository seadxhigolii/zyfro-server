using System;
using System.Collections.Generic;

namespace Zyfro.Pro.Server.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary) : this("Validation Failure!")
         => Errors = errorsDictionary;

        private ValidationException(string title)
            => Title = title;

        public string Title { get; }
        public IReadOnlyDictionary<string, string[]> Errors { get; }
    }
}
