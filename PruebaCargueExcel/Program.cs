using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PruebaCargueExcel;
using PruebaCargueExcel.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<PruebaCargueExcelContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MiConexion")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITmpCargueExcelService, TmpCargueExcelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
