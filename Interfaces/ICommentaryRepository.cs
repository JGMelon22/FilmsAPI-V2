using FilmsAPI_V2.DTOs.Commentary;

namespace FilmsAPI_V2.Interfaces;

public interface ICommentaryRepository
{
    Task AddCommentary(int MovieId, CommentaryInput newCommentary);
}