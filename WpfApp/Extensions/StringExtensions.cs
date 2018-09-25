using JetBrains.Annotations;

namespace Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty([CanBeNull] this string stringToValidate) => string.IsNullOrEmpty(stringToValidate);
    }
}
