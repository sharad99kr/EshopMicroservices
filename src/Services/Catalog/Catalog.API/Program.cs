
using BuildingBlocks.Exceptions.Handler;

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

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();
//configgure the HTTP request pipeline
app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
