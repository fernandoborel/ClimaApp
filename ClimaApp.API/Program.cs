using ClimaApp.Application.Extensions;
using ClimaApp.Domain.Extensions;
using ClimaApp.Infra.Data.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddHttpClient();
builder.Services.AddApplicationServices();
builder.Services.AddDomainServices();
builder.Services.AddEntityFramework(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapScalarApiReference(opt =>
{
    opt.WithTheme(ScalarTheme.BluePlanet);
});

app.UseAuthorization();

app.MapControllers();

app.Run();
