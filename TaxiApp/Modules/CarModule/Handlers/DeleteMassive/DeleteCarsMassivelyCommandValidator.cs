using FluentValidation;
using TaxiApp.Modules.Car.Handlers.DeleteMassive;

namespace TaxiApp.Modules.DriverModule.Handlers.Delete;

public class DeleteCarsMassivelyCommandValidator : AbstractValidator<DeleteCarsMassivelyCommand>
{
    public DeleteCarsMassivelyCommandValidator()
    {
        RuleFor(v => v)
            .NotEmpty()
            .DependentRules(() =>
            {
                RuleFor(v => v.IdsCars).NotEmpty();
            });
    }
}
