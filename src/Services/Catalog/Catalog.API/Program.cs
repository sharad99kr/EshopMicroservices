var builder = WebApplication.CreateBuilder(args);

//add services to the container

//carter
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
