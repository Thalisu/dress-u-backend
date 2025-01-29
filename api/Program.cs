using app.Config.Programs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Configuration.AddJsonFile(
        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        optional: false,
        reloadOnChange: true
     ).AddEnvironmentVariables();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenWithBearer();

builder.Services.AddNewtonsoftJsonController();
builder.Services.AddDBContextService(builder);

builder.Services.AddAuth(builder);

builder.Services.AddDependancies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
