using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _filmeContext;
    private IMapper _mapper;
    public FilmeController(FilmeContext filmeContext, IMapper mapper)
    {
        _filmeContext = filmeContext;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _filmeContext.Filmes.Add(filme);
        _filmeContext.SaveChanges();
        return CreatedAtAction(nameof(RecuperarFilmePorId),
            new { id = filme.Id },
            filme);
    }

    //retornando filmes
    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _filmeContext.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarFilmePorId(int id)
    {
        var filmeUnico = _filmeContext.Filmes
             .FirstOrDefault(filme => filme.Id == id);
        if (filmeUnico == null) return NotFound();

        return Ok(filmeUnico);
    }

    //update
    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody]
        UpdateFilmeDto updateFilmeDto)
    {
        var filmeAtualizacao = _filmeContext
            .Filmes
            .FirstOrDefault(filme => filme.Id == id);
        if(filmeAtualizacao == null) return NotFound();

        _mapper.Map(updateFilmeDto, filmeAtualizacao);
        //_filmeContext.Update(filmeAtualizacao); vou postar no linkdin
        _filmeContext.SaveChanges();
        return NoContent();
    }
    
}
