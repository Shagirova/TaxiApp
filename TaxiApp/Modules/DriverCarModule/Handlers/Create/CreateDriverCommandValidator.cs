using FluentValidation;

namespace TaxiApp.Modules.DriverCarModule.Handlers.Create;

public class CreateDriverCarCommandValidator : AbstractValidator<CreateDriverCarCommand>
{
    public CreateDriverCarCommandValidator()
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