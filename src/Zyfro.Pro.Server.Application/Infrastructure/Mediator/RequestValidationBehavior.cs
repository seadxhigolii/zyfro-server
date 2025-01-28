using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Zyfro.Pro.Server.Application.Infrastructure.Mediator
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validatonFailures = new List<ValidationFailure>();

            foreach (var validator in _validators)
            {
                var errors = (await validator.ValidateAsync(context, cancellationToken)).Errors;

                validatonFailures.AddRange(errors);
            }

            var serializedErrors = validatonFailures.GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                }).ToDictionary(x => x.Key, x => x.Values);

            if (validatonFailures.Count != 0)
            {
                throw new Common.Exceptions.ValidationException(serializedErrors);
            }

            return await next();
        }
    }
}
