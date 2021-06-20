using DeleteNodeModules.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DeleteNodeModules.Cli
{
    public static class Dependencies
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddMediatR(typeof(Constants));
        }
    }
}
