using BuberDinner.Common.Errors;
using BuberDinner.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
        services.AddMappings();

        return services;
    }
}