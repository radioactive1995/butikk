using butikk.Api.Motor;
using butikk.Api.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPrisRepository, PrisRepository>();
builder.Services.AddSingleton<ITilbudRepository, TilbudRepository>();
builder.Services.AddSingleton<IHandleKurvForretningMotor, HandleKurvForretningMotor>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
