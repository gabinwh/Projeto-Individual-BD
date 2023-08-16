namespace TrabPraticoBDIndividual.DTO;

public class UsuarioResponse
{
    public ulong Id { get; set; }
    public long cpf { get; set; }
    public string nome { get; set; }
    public DateOnly data_nascimento { get; set; }
}
