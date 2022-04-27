using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PlumGuide.Exercises.PlutoRover.DataAccess;
using PlumGuide.Exercises.PlutoRover.Endpoints.PlutoRover;
using PlumGuide.Exercises.PlutoRover.Registrations.MediatR;
using PlumGuide.Exercises.PlutoRover.Registrations.Middlewares;
using PlumGuide.Exercises.PlutoRover.Rovers.Abstractions;
using PlumGuide.Exercises.PlutoRover.Rovers.PlutoRover;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediator();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddTransient<IRover, PlutoRover>();
builder.Services.AddTransient<IMotionController, PlutoRoverMotionController>();

builder.Services.AddDbContext<PlutoRoverDbContext>(opt => opt.UseSqlServer(
        builder.Configuration["DbConnectionString"],
        b => b.EnableRetryOnFailure()));

builder.Services.AddHostedService<DataMigrationBackgroundWorker>();

// builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

app.UseRoverMiddlewares();

app.AddPlutoRoverEndpoints();

// app.MapControllers();

app.Run();
