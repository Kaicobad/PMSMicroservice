namespace BuildingBlocks.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    (IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));
        var failures =
            validationResults
            .Where(x => x.Errors.Count > 0) // Replaced .Any() with .Count > 0 for clarity and performance
            .SelectMany(x => x.Errors)
            .ToList();
        return failures.Count > 0 ? throw new ValidationException(failures) : await next(cancellationToken); // Replaced .Any() with .Count > 0
    }
}
