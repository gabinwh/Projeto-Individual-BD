using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabPraticoBDIndividual.DTO;
using TrabPraticoBDIndividual.Entities;

namespace TrabPraticoBDIndividual.Controllers;


[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public UsuarioController(DataContext dataContext, IMapper mapper)
    { 
        _dataContext = dataContext; 
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            List<Usuario> usuarios = await _dataContext.Usuarios.ToListAsync();

            return Ok(usuarios);
        }catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpPost]
    public async Task<IActionResult> Add(UsuarioStoreRequest request)
    {
       
        try
        {
            var validator = new UsuarioValidation();
            var results = validator.Validate(request);
            if (!results.IsValid) throw new Exception(results.ToString());
            if(request.cpf.ToString().Length == 10)
            {
                string cpfFormatado = "0" + request.cpf.ToString();
                if (!ValidarCPF(cpfFormatado)) throw new Exception("CPF inválido");
            }else if (request.cpf.ToString().Length == 11) 
            {
                if (!ValidarCPF(request.cpf.ToString())) throw new Exception("CPF inválido");
            }

            Usuario usuario = _mapper.Map<UsuarioStoreRequest, Usuario>(request);

            _dataContext.Usuarios.Add(usuario);
            await _dataContext.SaveChangesAsync();

            return Created("Sucesso", _mapper.Map<Usuario, UsuarioResponse>(usuario));
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    static bool ValidarCPF(string cpf)
    {
        // Remover todos os caracteres que não sejam dígitos
        string digits = new string(cpf.Where(char.IsDigit).ToArray());

        // Verificar se há 11 dígitos
        if (digits.Length != 11)
            return false;

        // Verificar se todos os dígitos são iguais
        if (digits.Distinct().Count() == 1)
            return false;

        // Calcular o primeiro dígito verificador
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += int.Parse(digits[i].ToString()) * (10 - i);
        }
        int firstVerifier = 11 - (sum % 11);
        if (firstVerifier >= 10)
            firstVerifier = 0;

        // Calcular o segundo dígito verificador
        sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += int.Parse(digits[i].ToString()) * (11 - i);
        }
        int secondVerifier = 11 - (sum % 11);
        if (secondVerifier >= 10)
            secondVerifier = 0;

        // Verificar se os dígitos verificadores calculados correspondem aos dígitos informados
        return digits[9] == firstVerifier.ToString()[0] && digits[10] == secondVerifier.ToString()[0];
    }
}
