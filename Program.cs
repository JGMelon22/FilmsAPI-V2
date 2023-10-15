using System.Data;
using FilmsAPI_V2.DTOs.Actor;
using FilmsAPI_V2.DTOs.Genre;
using FilmsAPI_V2.Infrastructure.Data;
using FilmsAPI_V2.Infrastructure.Mapping;
using FilmsAPI_V2.Infrastructure.Repositories;
using FilmsAPI_V2.Infrastructure.Validators.Actor;
using FilmsAPI_V2.Infrastructure.Validators.Genre;
using FilmsAPI_V2.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext service 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// IDBConnection
builder.Services.AddScoped<IDbConnection>(x =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("Default")));

// Mapster
builder.Services.RegisterMapsterConfiguration();

// Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<AddGenreDto>, AddGenreValidator>();
builder.Services.AddScoped<IValidator<UpdateGenreDto>, UpdateGenreValidator>();
builder.Services.AddScoped<IValidator<AddActorDto>, AddActorValidator>();
builder.Services.AddScoped<IValidator<UpdateActorDto>, UpdateActorValidator>();

// Interface and Repositories
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICommentaryRepository, CommentaryRepository>();

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
