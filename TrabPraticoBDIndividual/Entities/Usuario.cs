using System.ComponentModel.DataAnnotations;

namespace TrabPraticoBDIndividual.Entities;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required]
    public long cpf { get; set; }

    [Required]
    [StringLength(255)]
    public string nome { get; set; }

    [Required]
    public DateOnly data_nascimento { get; set; }
}
