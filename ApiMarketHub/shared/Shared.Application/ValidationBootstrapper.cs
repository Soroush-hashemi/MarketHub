using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.Validation;

namespace Shared.Application;
public class ValidationBootstrapper
{
    public static void Init(IServiceCollection service)
    {
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
    }
}