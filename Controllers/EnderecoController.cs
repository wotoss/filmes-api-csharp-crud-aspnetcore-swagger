using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private FilmeContext _filmeContext;
        private IMapper _mapper;

        public EnderecoController(FilmeContext filmeContext,
            IMapper mapper)
        {
            _filmeContext = filmeContext;
            _mapper = mapper;   
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _filmeContext.Enderecos.Add(endereco);
            _filmeContext.SaveChanges();

            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, endereco);
        }
        [HttpGet]
        public IEnumerable<ReadEnderecoDto> RecuperaEndereco()
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_filmeContext.Enderecos.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId (int id)
        {
            Endereco? endereco = _filmeContext.Enderecos
                .FirstOrDefault(enderecoLambda => enderecoLambda.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto readEnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return Ok(readEnderecoDto);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtulizarEndereco(int id, [FromBody] UpdateEnderecoDto updateEnderecoDto)
        {
            Endereco? enderecoBd = _filmeContext.Enderecos
                .FirstOrDefault(enderecoBd =>  enderecoBd.Id == id);
            if (enderecoBd == null) 
            {
                return NotFound();
            }
            _mapper.Map(updateEnderecoDto, enderecoBd);
            _filmeContext.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            Endereco? endereco = _filmeContext.Enderecos
                .FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null) 
            { 
                return NotFound();
            }
            _filmeContext.Remove(endereco);
            _filmeContext.SaveChanges();
            return NoContent();
        }

    }
}
