using GraphQl.Demo.Mutations;
using GraphQl.Demo.Queries;
using GraphQl.Demo.Schemas;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQL()
                .AddSystemTextJson();

            services.AddSingleton<NewsfeedQuery>();
            services.AddSingleton<NewsfeedMutation>();
            services.AddSingleton<ISchema, NewsfeedSchema>();

            services.AddLogging(builder => builder.AddConsole());
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground();

        }
    }
}
