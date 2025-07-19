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

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação
    /// de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
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
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_filmeContext.Filmes.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarFilmePorId(int id)
    {
        var filmeUnico = _filmeContext.Filmes
             .FirstOrDefault(filme => filme.Id == id);
        if (filmeUnico == null) return NotFound();

        var filmeDto = _mapper.Map<ReadFilmeDto>(filmeUnico);

        return Ok(filmeDto);
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

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmesParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filmePatch = _filmeContext.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filmePatch is null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filmePatch);
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmeParaAtualizar, filmePatch);
        _filmeContext.SaveChanges();
        return NoContent();
    }
    //vamos fazer o delete
    [HttpDelete("{id}")]
    public  IActionResult DeletaFilme(int id)
    {
        var filmeDelete =  _filmeContext.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filmeDelete is null) return NotFound();
        _filmeContext.Remove(filmeDelete);
        _filmeContext.SaveChanges();
        return NoContent();
    } 
}
