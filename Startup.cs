using System.Net;
using App.Contexts;
using App.Services;


namespace App.Startup;
public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void Configureservices(IServiceCollection services)
    {
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();

        services.AddSqlite<PersonContext>("Data Source=App.db");
        services.AddScoped<EmploymentService>();
        services.AddScoped<PersonService>();
    }
    public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            // endpoints.MapGet("/",async context=>
            // {
            //     Dictionary<string,string> map = new Dictionary<string,string> {{"Message","Person and employees head to /swagger/index.html to see operations or api/ endpoints to use the app"}};                
            //     context.Response.StatusCode=200;
            //     await context.Response.WriteAsJsonAsync(map);
            // });
            app.MapWhen(context=>context.Response.StatusCode == 404,(appBuilder)=>
            {
               appBuilder.Run(async context=>
               {
                context.Response.StatusCode=404;
                await context.Response.WriteAsJsonAsync("Resource Not found");
               }); 
            });

        });

        
    }
}