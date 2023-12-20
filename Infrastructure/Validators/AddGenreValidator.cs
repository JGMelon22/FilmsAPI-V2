using FilmsAPI_V2.DTOs.Genre;
using FluentValidation;

namespace FilmsAPI_V2.Infrastructure.Validators;

public class AddGenreValidator : AbstractValidator<GenreInput>
{
    public AddGenreValidator()
    {
        RuleFor(g => g.GenreName)
            .NotEmpty()
            .WithMessage("Genre Name must be informed!")
            .NotNull()
            .WithMessage("Genre Name must be informed!")
            .MaximumLength(150)
            .WithMessage("Genre Name can't exceed 150 characters long!");
    }
}