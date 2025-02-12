using Microsoft.EntityFrameworkCore;
using NzWalks.Data;
using NzWalks.Mappers;
using NzWalks.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
//Adding Database DI
// builder.Services.AddDbContext<NzWalkDbContext>(options =>
// options.UseSqlServer(builder.Configuration.GetConnectionString("NzWalkConnectionString")));

//DI of repository
builder.Services.AddScoped<IRegionRepository,SqlRegionRepository>();
builder.Services.AddScoped<IWalkRepository,SqlWalkRepository>();

//Adding Database DI
builder.Services.AddDbContext<NzWalkDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NzWalkConnectionString")));

//Add Auto Mapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();


app.MapControllers();
app.Run();

