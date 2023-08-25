using Microsoft.AspNetCore.Builder;
using WealthKernel.Todos.Service;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup();

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app);

app.Run();
