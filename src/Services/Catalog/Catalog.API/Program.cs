


using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

//add services to the container


var assembly = typeof(Program).Assembly;
//mediatR
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

//validator
builder.Services.AddValidatorsFromAssembly(assembly);

//carter. It simplifies the definition and configuration of routes in ASP.NET core
builder.Services.AddCarter();


//marten
builder.Services.AddMarten(opts => {
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

if(builder.Environment.IsDevelopment()) {
    //Seeding should only happen in development also we need to make sure DB is ready before we attempt to inject data(not yet handled)
    builder.Services.InitializeMartenWith<CatalogInitialData>();
}

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks().
    AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

var app = builder.Build();
//configgure the HTTP request pipeline
app.MapCarter();

app.UseExceptionHandler(options => { });

app.UseHealthChecks("/health",
    new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();
