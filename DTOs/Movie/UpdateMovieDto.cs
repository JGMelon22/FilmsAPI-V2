namespace FilmsAPI_V2.DTOs.Movie;

public record UpdateMovieDto(int MovieId, string Title, bool IsInCinema, DateTime ReleaseDate);