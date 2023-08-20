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
    public async Task<IActionResult> GetAll()
    {
        try
        {
            List<Usuario> usuarios = await _dataContext.Usuarios.ToListAsync();

            return Ok(usuarios);
        }catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            Usuario? usuario = await _dataContext.Usuarios.FindAsync(id);

            if(usuario == null) throw new NullReferenceException("A entidade não existe");

            return Ok(usuario);
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpPost]
    public async Task<IActionResult> Add(UsuarioStoreRequest request)
    {
       
        try
        {
            var validator = new UsuarioValidation();
            var results = validator.Validate(request);
            if (!results.IsValid) throw new Exception(results.ToString());

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
}
