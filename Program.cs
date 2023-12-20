using System.Data;
using FilmsAPI_V2.DTOs.Actor;
using FilmsAPI_V2.DTOs.Genre;
using FilmsAPI_V2.Infrastructure.Data;
using FilmsAPI_V2.Infrastructure.Mapping;
using FilmsAPI_V2.Infrastructure.Repositories;
using FilmsAPI_V2.Infrastructure.Validators;
using FilmsAPI_V2.Interfaces;
using FluentValidation;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS service
builder.Services.AddCors();

// DbContext service 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// IDBConnection
builder.Services.AddScoped<IDbConnection>(x =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("Default")));

// Mapster
builder.Services.RegisterMapsterConfiguration();

// Fluent Validation
builder.Services.AddScoped<IValidator<GenreInput>, GenreValidator>();
builder.Services.AddScoped<IValidator<ActorInput>, ActorValidator>();

// Interface and Repositories
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICommentaryRepository, CommentaryRepository>();

var app = builder.Build();

// CORS usage
app.UseCors(c =>
{
    c.WithOrigins("http://localhost:5173");
    c.AllowAnyHeader();
    c.AllowAnyMethod();
});

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