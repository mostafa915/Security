using FluentValidation;

namespace Security.DTOs.RailFence
{
    public class RailFenceRequestValidator : AbstractValidator<RailFenceRequest>
    {
        public RailFenceRequestValidator()
        {
            RuleFor(x => x.Text).NotEmpty();
            RuleFor(x => x.Key).GreaterThan(0);
        }
    }
}
