using FluentValidation;

namespace TrabPraticoBDIndividual.DTO;

public class UsuarioValidation : AbstractValidator<UsuarioStoreRequest>
{
    public UsuarioValidation()
    {
        RuleFor(x => x.nome)
            .NotEmpty()
            .WithMessage("O campo nome não pode ser vazio")
            .MaximumLength(255)
            .WithMessage("O campo nome deve possuir no máximo 255 caracteres");
        RuleFor(x => x.data_nascimento)
            .NotEmpty()
            .WithMessage("O campo data de nascimento não pode ser vazio")
            .Must(IsDateBeforeToday)
            .WithMessage("Data inválida");
        RuleFor(x => x.cpf)
            .NotEmpty()
            .WithMessage("O campor cpf não pode ser vazio");
    }

    public static bool IsDateBeforeToday(DateOnly date)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now.Date);
        return date <= today;
    }
}
