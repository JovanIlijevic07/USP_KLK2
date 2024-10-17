using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using USP_Application.Common.Exceptions;

namespace USP_API.Filters;

public class ApiExceptionFilter: ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ApiExceptionFilter()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            //ovde idu pravila prvi je moj exception
            {typeof(CustomValidationException),HandleCustomValidationException},
            {typeof(ValidationException),HandleFluentValidationException}
        };
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);
        
        base.OnException(context);
    }

    public void HandleException(ExceptionContext context)
    {
        var type = context.Exception.GetType();

        if (_exceptionHandlers.TryGetValue(type, out var handler))
        {
            handler.Invoke(context);
            return;
        }
        HandleUnknownException(context);
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Desio se ERROR",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
        
        context.ExceptionHandled = true;
    }
    
    private void HandleFluentValidationException(ExceptionContext context)
    {   var exception = (FluentValidation.ValidationException)context.Exception;
        var failures = exception.Errors.GroupBy(e => 
            e.PropertyName,e => e.ErrorMessage)        .ToDictionary(x => x.Key, 
            x => x.ToArray());    var details = new ValidationProblemDetails(failures)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"    
            
        };   
        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
        
    }
    
    private void HandleCustomValidationException(ExceptionContext context)
    
    {    var exception = (CustomValidationException)context.Exception;
        var details = new ValidationProblemDetails((IDictionary<string, string[]>)exception.AdditionalData!)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };  
        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
        
    }
}