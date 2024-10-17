using FluentValidation.Results;

namespace USP_Application.Common.Extentions;

public static class ValidationExtentions
{
    public static IDictionary<string, string[]> ToGroup(this IEnumerable<ValidationFailure> validationFailures)
    {
        return validationFailures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key,
                failureGroup => failureGroup.ToArray());
        
    }
}