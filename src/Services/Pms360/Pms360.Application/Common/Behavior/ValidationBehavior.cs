namespace Pms360.Application.Common.Behavior;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> ,IValidatable
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResult = await Task
                .WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            if (!validationResult.Any(vr=>vr.IsValid))
            {
                var errorMessages = new List<string>();
                var failures = validationResult.SelectMany(vr => vr.Errors)
                    .Where(f => f != null)
                    .ToList();

                foreach (var failure in failures)
                {
                    errorMessages.Add(failure.ErrorMessage);
                }
                return (TResponse)Response.Response.Fail(Message: errorMessages);
            }
        }
        return await next();
    }
}
