using MediatR;
using ErrorOr;
using FluentValidation;

namespace BuberDinner.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
            await next();
        
        var validationResult = await _validator.ValidateAsync(request);

        if (validationResult.IsValid)
        {
            // before the handler
            return await next();
            //after the handler
        }

        var errors = validationResult.Errors
            .ConvertAll(x =>
                Error.Validation(x.PropertyName, x.ErrorMessage));

        return (dynamic)errors;
    }
}