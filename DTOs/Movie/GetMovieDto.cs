namespace FilmsAPI_V2.DTOs.Movie;

public record GetMovieDto(int MovieId, string Title, bool IsInCine, DateTime ReleaseDate);