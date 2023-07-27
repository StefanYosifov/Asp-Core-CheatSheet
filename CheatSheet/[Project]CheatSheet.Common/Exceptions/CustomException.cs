namespace _Project_CheatSheet.Common.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;

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
