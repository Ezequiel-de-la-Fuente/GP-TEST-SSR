namespace GP.Test.Apis.Controllers
{
    using Gp.Test.Api.DTO;
    using Gp.Test.Interface.Mapper;
    using Gp.Test.Interface.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonasRepository _IPersonasRepository;
        private readonly IPersonasMapper _IPersonasMapper;
        public PersonasController(IPersonasRepository IPersonasRepository, IPersonasMapper IPersonasMapper)
        {
            _IPersonasRepository = IPersonasRepository;
            _IPersonasMapper = IPersonasMapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var personas = _IPersonasRepository.GetAll();
                return Ok(_IPersonasMapper.MapEntityToDTO(personas));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var persona = _IPersonasRepository.GetBy(id);
                if(persona == null)
                {
                    return NotFound();
                }
                return Ok(_IPersonasMapper.MapEntityToDTO(persona));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonasDTO dto)
        {
            try
            {
                var persona = _IPersonasRepository.Create(_IPersonasMapper.MapDtoToEntity(dto));
                return Ok(_IPersonasMapper.MapEntityToDTO(persona));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Update([FromBody] PersonasDTO dto)
        {
            try
            {
                var persona = _IPersonasRepository.Update(_IPersonasMapper.MapDtoToEntity(dto));
                return Ok(_IPersonasMapper.MapEntityToDTO(persona));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
