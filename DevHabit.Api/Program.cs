using DevHabit.Api;
using DevHabit.Api.Database;
using DevHabit.Api.DTOs.Habits;
using DevHabit.Api.Entities;
using DevHabit.Api.Extensions;
using DevHabit.Api.Middleware;
using DevHabit.Api.Services;
using DevHabit.Api.Services.Sorting;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json.Serialization;
using Npgsql;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddControllers()
    .AddErrorHandling()
    .AddDatabase()
    .AddObservability()
    .AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    await app.ApplyMigrationsAsync();
}
app.UseHttpsRedirection();
app.UseExceptionHandler();

//app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
