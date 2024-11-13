using XBuddy.API.Infrastructure.MultiTenant.Extensions;
using XBuddy.API.Infrastructure.MultiTenant.Services;
using XBuddy.Domain;
using XBuddy.Infrastructure.CosmosCache.Extensions;
using XBuddy.Infrastructure.SqlServer.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfraSqlServices(builder.Configuration.GetConnectionString("SqlServer"), (sp) =>
{
    var service = sp.GetRequiredService<IMultiTenantService>();

    return service.GetUserId().ToString();
});
builder.Services.AddDomain(builder.Configuration);
builder.Services.AddMultiTenancy();
builder.Services.AddInfraCosmosServices(builder.Configuration.GetConnectionString("CosmosCache"));

var app = builder.Build();

app.UseMultiTenancy();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();