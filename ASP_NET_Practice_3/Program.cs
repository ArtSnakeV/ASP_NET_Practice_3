using ASP_NET_Practice_3.Middleware;
using ASP_NET_Practice_3.Services.Abstract;
using ASP_NET_Practice_3.Services.Implementations;
using System.Runtime.CompilerServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<INumberService, FactorialService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();


//IServiceCollection services;
//public void ConfigureServices (IServiceCollection services)
//{
//    this.services = services;
//}

app.UseMiddleware<NumberMiddleware>(); // Start using our middleware
app.Run(async context=>
{
    string message = "Not found!";
    // Using Service Locator
    context.RequestServices.GetRequiredService<INumberService>();
    context.Response.ContentType = "text/html;charset=utf-8";
    // Sending our `message` to the User if not found any proper page
    await context.Response.WriteAsync(message);
});









app.Run();
