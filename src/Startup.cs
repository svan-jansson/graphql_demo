using GraphQL.Demo.DocumentExecuter;
using GraphQL.Demo.Middleware;
using GraphQL.Demo.NewsfeedData;
using GraphQL.Demo.Schemas;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Demo
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
            app.UseGraphQL<ISchema, GraphQLHttpMiddlewareWithLogs<ISchema>>();
            app.UseGraphQLPlayground();
        }
    }
}
