using AutoMapper;
using MeusFilmes.Api.Data;
using MeusFilmes.Api.Repository;
using MeusFilmes.Api.Repository.IRepository;
using MeusFilmes.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SqLite
builder.Services.AddDbContext<AppDbContext>(context =>
    context.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

//Repository
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddAutoMapper(typeof(FilmesMapper));
//builder.Services.AddAutoMapper(cfg => { }, typeof(FilmesMapper));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();