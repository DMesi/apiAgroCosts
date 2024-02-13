using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageServiceLibrary.DTO;
using StorageServiceLibrary.IRepository;
using StorageServiceLibrary.Model;

namespace apiAC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;


        public PlanController(IUnitOfWork unitOfWork, ILogger<PlanController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlan()
        {
            try
            {
                var plans = await _unitOfWork.Plans.GetAll();
                var results = _mapper.Map<List<PlanDTO>>(plans);  
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wronk un the {nameof(GetPlan)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }

        }

        [HttpGet("{id:int}", Name = "GetPlan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> plan(int id)
        {
            try
            {
                var plan = await _unitOfWork.Plans.customQuery(q => q.FieldRefId == id);
       
                var result = _mapper.Map<List<PlanDTO>>(plan);

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

        public async Task<IActionResult> CreatePlann([FromBody] PlanDTO planDTO)
        {
            if (!ModelState.IsValid)
            {

                _logger.LogError($"Invalid POST atempt in {nameof(CreatePlann)}");
                return BadRequest(ModelState);

            }

            try
            {
                var newPlan = _mapper.Map<Plan>(planDTO);
                await _unitOfWork.Plans.Insert(newPlan);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetPlan", new { id = newPlan.Id_plan }, newPlan);   // da bi ovo radilo prikazalo novo kreiranu lokaciju moramo dodati  [HttpGet("{id:int}", Name = "GetLocation")]

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreatePlann)}");
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
        public async Task<IActionResult> DeletePlan(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE atempt in {nameof(DeletePlan)}");
                return BadRequest(ModelState);
            }
            try
            {
                var plan = await _unitOfWork.Plans.Get(q => q.Id_plan == id);
                if (plan == null)
                {
                    _logger.LogError($"Invalid DELETE atempt in {nameof(DeletePlan)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Plans.Delete(id);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(DeletePlan)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }

    }
}
