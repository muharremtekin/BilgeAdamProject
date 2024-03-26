using BilgeAdamProject.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(BilgeAdamProject.Presentation.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureApplicationDbContext(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.ConfigureSerilog();
builder.Services.ConfigureCors();
builder.Services.AddResponseCaching();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRequestLoggerMiddleware();

app.UseResponseCaching();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();