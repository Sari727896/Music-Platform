using BL.BlApi;
using BL.BlImplementaion;
using Dal.DalApi;
using Dal.Dalimplementaion;
using Dal.Do;
using Dal;
using Microsoft.EntityFrameworkCore;
using BL;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

DBActions db = new DBActions(builder.Configuration);
string connStr = db.GetConnectionString("MusicDB");
builder.Services.AddScoped<BLManager>(x => new BLManager(connStr));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
