using FluentValidation;

namespace Security.DTOs.Playfair
{
    public class PlayfairRequestValidator : AbstractValidator<PlayfairRequest>
    {
        public PlayfairRequestValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty();

            RuleFor(x => x.Key)
                .NotEmpty();
        }
    }
}
