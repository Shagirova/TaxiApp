using FluentValidation;

namespace TaxiApp.Modules.DriverModule.Handlers.Create;

public class CreateDriverCommandValidator : AbstractValidator<CreateDriverCommand>
{
    public CreateDriverCommandValidator()
    {
        RuleFor(v => v)
           .NotEmpty()
           .DependentRules(() =>
           {
               RuleFor(v => v.Driver).NotEmpty()
               .ChildRules(i =>
               {
                   i.RuleFor(s => s.FirstName).NotEmpty().MaximumLength(128);
                   i.RuleFor(s => s.LastName).NotEmpty().MaximumLength(128);
                   i.RuleFor(s => s.MiddleName).MaximumLength(128);
               });
           });
    }
}