namespace USP_Application.Common.Exceptions;

public class CustomValidationException:BaseException
{
    public CustomValidationException(IDictionary<string, string[]> failures) : base("bilo je validation exceptiona",
        failures)
    {
        
    }
}