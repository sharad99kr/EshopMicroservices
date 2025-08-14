var builder = WebApplication.CreateBuilder(args);
//add services to the container
var app = builder.Build();
//configgure the HTTP request pipeline
app.Run();
