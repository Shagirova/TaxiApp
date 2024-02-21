using FluentValidation;

namespace TaxiApp.Modules.DriverModule.Handlers.Delete;

public class DeleteDriverCommandValidator : AbstractValidator<DeleteDriverCommand>
{
    public DeleteDriverCommandValidator()
    {
        RuleFor(v => v)
            .NotEmpty()
            .DependentRules(() =>
            {
                RuleFor(v => v.IdDriver).NotEmpty();
            });
    }
}
