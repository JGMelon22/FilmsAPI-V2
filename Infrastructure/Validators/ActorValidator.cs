using FilmsAPI_V2.DTOs.Actor;
using FluentValidation;

namespace FilmsAPI_V2.Infrastructure.Validators;

public class ActorValidator : AbstractValidator<ActorInput>
{
    public ActorValidator()
    {
        RuleFor(a => a.ActorName)
            .NotEmpty()
            .WithMessage("Actor Name must be informed!")
            .NotNull()
            .WithMessage("Actor Name must be informed!")
            .MaximumLength(150)
            .WithMessage("Actor Name can't exceed 150 characters!");

        RuleFor(a => a.Salary)
            .NotEmpty()
            .WithMessage("Actor Salary must be informed!")
            .NotNull()
            .WithMessage("Actor Salary must be informed!")
            .Must(salary => salary >= 1.0M)
            .WithMessage($"Actor Salary out of range!")
            .Must(salary => salary <= 9999999.99M)
            .WithMessage($"Actor Salary out of range!");

        RuleFor(a => a.BirthDate)
            .NotEmpty()
            .WithMessage("Actor Birthdate must be informed!")
            .NotNull()
            .WithMessage("Actor Birthdate must be informed!")
            .Must(birthDate => birthDate < DateTime.Now)
            .WithMessage("Invalid Actor Birthdate!");
    }
}