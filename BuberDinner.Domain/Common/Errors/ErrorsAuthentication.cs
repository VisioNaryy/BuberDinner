using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error DuplicateEmail =>
            Error.Conflict(code: $"{nameof(Authentication)}.{nameof(DuplicateEmail)}", description: "Email already exists.");
    }
}