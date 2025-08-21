using BuildingBlocks.Behaviors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//add services to the container


var assembly = typeof(Program).Assembly;
//mediatR
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

//validator
builder.Services.AddValidatorsFromAssembly(assembly);

//carter. It simplifies the definition and configuration of routes in ASP.NET core
builder.Services.AddCarter();


//marten
builder.Services.AddMarten(opts => {
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();
//configgure the HTTP request pipeline
app.MapCarter();

app.UseExceptionHandler(exceptionHandlerApp => {
    exceptionHandlerApp.Run(async context => {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if(exception == null) { 
            return;
        }

        var problemDetails = new ProblemDetails { 
            Title=exception.Message,
            Status=StatusCodes.Status500InternalServerError,
            Detail=exception.StackTrace
        };

        var logger=context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, exception.Message);

        context.Response.StatusCode=StatusCodes.Status500InternalServerError;
        context.Response.ContentType="application/problem+json";
        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});
app.Run();
