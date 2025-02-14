using System.Runtime.CompilerServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.UseDefaultFiles();
//app.UseStaticFiles();


//app.UseMiddleware<AboutMiddleware>();
//app.UseMiddleware<ContactsMiddleware>();

//IServiceCollection services;
//public void ConfigureServices (IServiceCollection services)
//{
//    this.services = services;
//}










app.Run();
