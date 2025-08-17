var builder = WebApplication.CreateBuilder(args);

//add services to the container

//carter. It simplifies the definition and configuration of routes in ASP.NET core
builder.Services.AddCarter();
//mediatR
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
//marten
builder.Services.AddMarten(opts => {
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();
//configgure the HTTP request pipeline
app.MapCarter();
app.Run();
