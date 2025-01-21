using Microsoft.EntityFrameworkCore;
using top_bod_be;
using top_bod_be.Data;
using top_bod_be.Models;
using top_bod_be.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<NutritionDetailsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NutritionDetailsContext")));
builder.Services.AddScoped<INutritionService, NutritionService>();
builder.Services.AddScoped<IDataRepo, DataRepo>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

//Use CORS policy
app.UseCors("AllowSpecificOrigins");

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
