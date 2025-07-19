using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private FilmeContext _filmeContext;
        private IMapper _mapper;

        public CinemaController(FilmeContext filmeContext, IMapper mapper)
        {
            _filmeContext = filmeContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _filmeContext.Cinemas.Add(cinema);
            _filmeContext.SaveChanges();
            //vou retornar o que eu criei
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = cinema.Id }, cinemaDto);   
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDto> RecuperaCinemas()
        {
            var recebendo = _mapper.Map<List<ReadCinemaDto>>(_filmeContext.Cinemas.ToList());
            return recebendo;   
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId (int id)
        {
            Cinema? cinema = _filmeContext.Cinemas.FirstOrDefault(cinemaLambda => cinemaLambda.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto updateCinemaDto)
        {
            Cinema? cinemaRecebidoBd = _filmeContext.Cinemas
                .FirstOrDefault(cinema => cinema.Id == id);
            if (cinemaRecebidoBd == null)
            {
                return NotFound();
            }
            _mapper.Map(updateCinemaDto, cinemaRecebidoBd);
            _filmeContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Cinema? cinema = _filmeContext.Cinemas
                .FirstOrDefault(cinemaLambda => cinemaLambda.Id == id);
            if (cinema == null) 
            {
                return NotFound();
            }
            _filmeContext.Remove(cinema);
            _filmeContext.SaveChanges();
            return NoContent();
        }
        //[HttpDelete]
    }
}
