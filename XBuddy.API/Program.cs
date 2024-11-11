using XBuddy.API.Infrastructure.MultiTenant.Extensions;
using XBuddy.Domain;
using XBuddy.Domain.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDomain(builder.Configuration);
builder.Services.AddMultiTenancy();


var app = builder.Build();

app.UseMultiTenancy();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();