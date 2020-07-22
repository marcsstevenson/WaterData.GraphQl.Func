using FluentValidation;

namespace WaterData.GraphQl.Functions.Testing.RequestHelperFixtures
{
    public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
    {
        public ExampleRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
