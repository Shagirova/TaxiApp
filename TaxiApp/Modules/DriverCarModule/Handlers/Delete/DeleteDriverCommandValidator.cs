using FluentValidation;

namespace TaxiApp.Modules.DriverCarModule.Handlers.Delete;

public class DeleteDriverCarCommandValidator : AbstractValidator<DeleteDriverCarCommand>
{
    public DeleteDriverCarCommandValidator()
    {
        RuleFor(v => v)
           .NotEmpty()
           .DependentRules(() =>
           {
               RuleFor(v => v.DriverCarRequest).NotEmpty()
               .ChildRules(i =>
               {
                   i.RuleFor(s => s.IdCar).NotEmpty();
                   i.RuleFor(s => s.IdDriver).NotEmpty();
               });
           });
    }
}