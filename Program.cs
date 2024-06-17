using App.Contexts;
using App.Services;
using App.Startup;
using Microsoft.AspNetCore;
// var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddControllers();

// builder.Services.AddSqlite<PersonContext>("Data Source=App.db");
// builder.Services.AddScoped<EmploymentService>();
// var app = builder.Build();


// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }



// app.UseAuthorization();

// app.MapControllers();
// app.UseRouting();

// app.MapGet("/",()=>@"Person and emploeyyes head to /swagger to se operations or api/ endpoints to use the app");


// app.Run();

public class Program
{
    public static void Main(string[] args)
    {
        var app= WebHostBuilder(args);

        app.Build().Run();
        
    }

    public static IWebHostBuilder WebHostBuilder(string [] args)=> 
    WebHost.CreateDefaultBuilder(args)
    .UseStartup<Startup>();
}


