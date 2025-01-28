using Zyfro.Pro.Server.Application.Infrastructure.Mediator;
using Zyfro.Pro.Server.Application.Interfaces;
using MediatR;

namespace Zyfro.Pro.Server.Api.Extensions.Configurations
{
    public static class MediatorExtension
    {
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(IProDbContext).Assembly);
                options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
                options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            });
        }
    }
}
