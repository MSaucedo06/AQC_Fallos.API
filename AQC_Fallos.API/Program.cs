using AQC_Fallos.Data.Context;
using AQC_Fallos.Data.Repositories;
using AQC_Fallos.Data.Repositories.Interfaces;
using AQC_Fallos.Service;
using AQC_Fallos.Service.Services;
using AQC_Fallos.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SQLServerConnection");


builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddTransient<IFallasRepository, FallasRepository>();
builder.Services.AddTransient<IFallasService, FallasService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
