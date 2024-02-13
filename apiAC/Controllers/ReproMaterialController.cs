using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StorageServiceLibrary.DTO;
using StorageServiceLibrary.IRepository;
using StorageServiceLibrary.Model;

namespace apiAC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReproMaterialController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<PlanController> _logger;

        public ReproMaterialController(IUnitOfWork unitOfWork, ILogger<PlanController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRepro()
        {
            try
            {
                var plans = await _unitOfWork.ReproMaterials.GetAll();
                var results = _mapper.Map<List<ReproMaterialDTO>>(plans);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wronk un the {nameof(GetRepro)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }

        }

        [HttpGet("{id:int}", Name = "GetRepro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> reproMaterial(int id)
        {
            try
            {
                var repro = await _unitOfWork.ReproMaterials.customQuery(q => q.Id_Repro == id);
              
                var result = _mapper.Map<List<ReproMaterialDTO>>(repro);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wronk un the");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        //   [Authorize(Roles = "Administrator ")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateRepro([FromBody] ReproMaterialDTO reproDTO)
        {
            if (!ModelState.IsValid)
            {

                _logger.LogError($"Invalid POST atempt in {nameof(CreateRepro)}");
                return BadRequest(ModelState);

            }

            try
            {
                var newRepro = _mapper.Map<ReproMaterial>(reproDTO);

                await _unitOfWork.ReproMaterials.Insert(newRepro);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetPlan", new { id = newRepro.Id_Repro }, newRepro);   // da bi ovo radilo prikazalo novo kreiranu lokaciju moramo dodati  [HttpGet("{id:int}", Name = "GetLocation")]

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreateRepro)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePlan(int id, [FromBody] PlanDTO planDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE atempt in {nameof(UpdatePlan)}");
                return BadRequest(ModelState);
            }
            try
            {
                var plan = await _unitOfWork.Plans.Get(q => q.Id_plan == id);
                if (plan == null)
                {
                    _logger.LogError($"Invalid UPDATE atempt in {nameof(UpdatePlan)}"); //ime kontrolera
                    return BadRequest("Submitted data is invalid");

                }
                _mapper.Map(planDTO, plan);
                _unitOfWork.Plans.Update(plan);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdatePlan)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRepro(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE atempt in {nameof(DeleteRepro)}");
                return BadRequest(ModelState);
            }
            try
            {
                var repro = await _unitOfWork.ReproMaterials.Get(q => q.Id_Repro == id);
                if (repro == null)
                {
                    _logger.LogError($"Invalid DELETE atempt in {nameof(DeleteRepro)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Plans.Delete(id);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(DeleteRepro)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }


    }
}
