using FluentValidation;

namespace Security.DTOs.AutoKey
{
    public class AutoKeyRequestValidator : AbstractValidator<AutoKeyRequest>
    {
        public AutoKeyRequestValidator()
        {
            RuleFor(x => x.Text).NotEmpty();
            RuleFor(x => x.Key).NotEmpty();
        }
    }
}
