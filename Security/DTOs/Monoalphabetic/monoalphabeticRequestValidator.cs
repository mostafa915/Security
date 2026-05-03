using FluentValidation;

namespace Security.DTOs.Monoalphabetic
{
    public class monoalphabeticRequestValidator : AbstractValidator<monoalphabeticRequest>
    {
        public monoalphabeticRequestValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty();

            RuleFor(x => x.Key)
                .NotEmpty()
                .Length(26);

            RuleFor(x => x.Key)
                .Must(BeValidAlphabetKey)
                .WithMessage("The key must contain all 26 alphabetical characters exactly once, without duplicates or symbols.")
                .When(x => !string.IsNullOrEmpty(x.Key));
        }

        private bool BeValidAlphabetKey(string key)
        {
            var normalizedKey = key.ToLower();
            
            if (!normalizedKey.All(char.IsLetter))
                return false;

            var uniqueCharsCount = normalizedKey.Distinct().Count();
            return uniqueCharsCount == 26;
        }
    }
}
