using FluentValidation;

namespace Security.DTOs.Caesar
{
    public class CaesarRequestValidator : AbstractValidator<CaesarRequest>
    {
        public CaesarRequestValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty();


        }
    }
}
