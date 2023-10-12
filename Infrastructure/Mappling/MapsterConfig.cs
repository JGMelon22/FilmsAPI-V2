using FilmsAPI_V2.DTOs.Movie;
using Mapster;

namespace FilmsAPI_V2.Infrastructure.Mapping;

public static class MapsterConfig
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig<AddMovieDto, Movie>
        .NewConfig()
        .Map(dest => dest.Genres, src => src.Genres.Select(id => new Genre { GenreId = id }));
    }
}