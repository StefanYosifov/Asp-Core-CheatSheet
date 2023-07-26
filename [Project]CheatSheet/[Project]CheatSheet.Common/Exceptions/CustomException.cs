namespace _Project_CheatSheet.Common.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomException : Exception
    {
        private const string ExceptionError = "Object is null";

        public CustomException(string message)
            : base(message)
        {
        }

        public static void ThrowIfNull([NotNull] object? argument, string? message = ExceptionError)
        {
            if (argument == null)
            {
                Throw(message);
            }
        }

        private static void Throw(string? message)
            => throw new CustomException(message);

    }
}
