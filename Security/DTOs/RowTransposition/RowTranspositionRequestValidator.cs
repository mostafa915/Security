using FluentValidation;

namespace Security.DTOs.RowTransposition
{
    public class RowTranspositionRequestValidator : AbstractValidator<RowTranspositionRequest>
    {
        public RowTranspositionRequestValidator()
        {
            RuleFor(x => x.Text).NotEmpty();
            RuleFor(x => x.Key).NotEmpty();
        }
    }
}
