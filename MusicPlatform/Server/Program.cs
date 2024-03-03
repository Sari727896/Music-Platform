using BL.BlApi;
using BL.BlImplementaion;
using Dal.DalApi;
using Dal.Dalimplementaion;
using Dal.Do;
using Dal;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//ìòùåú àú æä áconfigure sevices
builder.Services.AddAutoMapper(typeof(Program));
// Add services to the container.

builder.Services.AddControllers();

DBActions db = new DBActions(builder.Configuration);
string connStr = db.GetConnectionString("MusicDB");
builder.Services.AddDbContext<MusicContext>(opt => opt.UseSqlServer(connStr));
builder.Services.AddScoped<ISongRepoDal, SongRepo>();
builder.Services.AddScoped<ISongRepoBl, SongServiceBl>();
builder.Services.AddScoped<ISingerRepoDal, SingerRepo>();
builder.Services.AddScoped<ISingerRepoBl, SingerServiceBl>();

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
