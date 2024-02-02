using Learnify.APIGateway.Extensions;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
//builder.AddAppAuthetication();
builder.Services.AddOcelot();
var app = builder.Build();
app.UseOcelot().GetAwaiter().GetResult();
app.Run();
