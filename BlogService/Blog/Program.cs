using Blog.Application.Extensions;
using Blog.Extensions;
using Blog.Infrastructure.Data;
using NLog;
using NLog.Config;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();
var scope = app.Services.CreateScope();
app.AddApplicationServiceBuilder(scope);


if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

public partial class Program{}

