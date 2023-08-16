namespace TrabPraticoBDIndividual.DTO;

public class UsuarioStoreRequest 
{
    public long cpf { get; set; }
    public string nome { get; set; }

    public DateOnly data_nascimento { get; set; }
}
