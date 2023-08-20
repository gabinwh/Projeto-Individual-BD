using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabPraticoBDIndividual.DTO;
using TrabPraticoBDIndividual.Entities;

namespace TrabPraticoBDIndividual.Controllers;


[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMapper _mapper;
    private static List<Usuario?> _usuariosList = new List<Usuario?>();

    public UsuarioController(IMapper mapper)
    { 
        _mapper = mapper;
    }
    [HttpGet]
    public List<UsuarioResponse> GetAll()
    {
            return _mapper.Map<List<UsuarioResponse>>(_usuariosList);
    }

    [HttpGet("{id}")]
    public UsuarioResponse Get(int id)
    {
        if(_usuariosList.Count() == 0) { throw new NullReferenceException("A entidade não existe"); }
        Usuario? usuario = _usuariosList.FirstOrDefault(u => u.Id == id);

        if(usuario == null) throw new NullReferenceException("A entidade não existe");

        return _mapper.Map<UsuarioResponse>(usuario); 


    }

    [HttpPost]
    public UsuarioResponse Add(UsuarioStoreRequest request)
    {
        Usuario usuario = _mapper.Map<UsuarioStoreRequest, Usuario>(request);
        usuario.Id = _usuariosList.Count() +1;
        _usuariosList.Add(usuario);

        return _mapper.Map<UsuarioResponse>(usuario);
    }
}
