﻿namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] Handle requestType = {RequestType} - responseType = {ResponseType} - requestData = {RequestData}",
                typeof(TRequest).Name, typeof(TResponse).Name, request);

            var timer = new Stopwatch();
            timer.Start();

            var response = await next(cancellationToken);
            timer.Stop();

            var timeTaken = timer.Elapsed;
            if (timeTaken.TotalSeconds > 3)
            {
                logger.LogWarning("[PERFORMANCE] The request {RequestType} took {TimeTaken}s", typeof(TRequest).Name, timeTaken.TotalSeconds);
            }

            logger.LogInformation("[END] Handle {RequestType} With {ResponseType}", typeof(TRequest).Name, typeof(TResponse).Name);
            return response;
        }
    }
}
