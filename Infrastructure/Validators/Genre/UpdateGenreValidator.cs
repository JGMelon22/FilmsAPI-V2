using FilmsAPI_V2.DTOs.Genre;
using FluentValidation;

namespace FilmsAPI_V2.Infrastructure.Validators.Genre;

public class UpdateGenreValidator : AbstractValidator<UpdateGenreDto>
{
    public UpdateGenreValidator()
    {
        RuleFor(g => g.GenreId)
        .NotEmpty()
        .WithMessage("Genre Id must be informed!")
        .NotNull()
        .WithMessage("Genre Id must be informed!");

        RuleFor(g => g.GenreName)
        .NotEmpty()
        .WithName("Genre Name must be informed!")
        .NotNull()
        .WithMessage("Genre Name must be informed!")
        .MaximumLength(150)
        .WithMessage("Genre Name can't exceed 150 characters long!");
    }
}