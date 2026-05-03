using FluentValidation;

namespace Security.DTOs.Vigenere
{
    public class VigenereRequestValidator : AbstractValidator<VigenereRequest>
    {
        public VigenereRequestValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty();

            RuleFor(x => x.Key)
                .NotEmpty();
        }
    }
}
