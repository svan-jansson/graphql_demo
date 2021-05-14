using GraphQl.Demo.NewsfeedData;
using GraphQl.Demo.Queries;
using GraphQl.Demo.Schemas;
using GraphQl.Demo.Types;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            services.AddGraphQL()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddSystemTextJson();

            services.AddSingleton<StoryType>();
            services.AddSingleton<AuthorType>();
            services.AddSingleton<INewsfeedData, MockNewsfeedData>();
            services.AddSingleton<NewsfeedQuery>();
            //services.AddSingleton<NewsfeedMutation>();
            services.AddSingleton<ISchema, NewsfeedSchema>();

            services.AddLogging(builder => builder.AddConsole());
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground();

        }
    }
}
