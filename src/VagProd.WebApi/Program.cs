using MagProd.Infrastructure;
using MagProduct.Application;
using VagProd.WebApi;
using VagProd.WebApi.Seeding;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services
    .AddWebApi(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration);
    

//builder.Services.AddScoped<IValidator<UserRegRequest>, UserValidator>();


var app = builder.Build();
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
    Console.WriteLine($"Running in env: {app.Environment.EnvironmentName}");
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

var scope=app.Services.CreateScope();
var seed = scope.ServiceProvider.GetRequiredService<Seed>();
await seed.Seeding();


app.Run();