using GraphQl.Demo.DocumentExecuter;
using GraphQl.Demo.Middleware;
using GraphQl.Demo.NewsfeedData;
using GraphQl.Demo.Schemas;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<INewsfeedData, MockNewsfeedData>()
                .AddSingleton<ISchema, NewsfeedSchema>()
                .AddSingleton<IDocumentExecuter, DocumentExecuterWithSubscriptions>()
                .AddGraphQL()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddSystemTextJson()
                .AddWebSockets()
                .AddGraphTypes(typeof(NewsfeedSchema));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseWebSockets();
            app.UseGraphQLWebSockets<ISchema>();
            app.UseGraphQL<ISchema, GraphQlHttpMiddlewareWithLogs<ISchema>>();
            app.UseGraphQLPlayground();
        }
    }
}
