using FluentValidation;
using TaxiApp.Modules.DriverModule.Handlers.Update;

namespace TaxiApp.Modules.DriverModule.Handlers.Create;

public class UpdateDriverCommandValidator : AbstractValidator<UpdateDriverCommand>
{
    public UpdateDriverCommandValidator()
    {
        RuleFor(v => v)
           .NotEmpty()
           .DependentRules(() =>
           {
               RuleFor(v => v.Driver).NotEmpty()
               .ChildRules(i =>
               {
                   i.RuleFor(s => s.IdDriver).NotEmpty();
                   i.RuleFor(s => s.FirstName).NotEmpty().MaximumLength(128);
                   i.RuleFor(s => s.LastName).NotEmpty().MaximumLength(128);
                   i.RuleFor(s => s.MiddleName).MaximumLength(128);
               });
           });
    }
}
