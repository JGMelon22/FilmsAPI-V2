namespace FilmsAPI_V2.DTOs.Movie;

public record MovieResult(int MovieId, string Title, bool IsInCinema, DateTime ReleaseDate);