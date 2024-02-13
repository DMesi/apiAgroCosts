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
    public class FieldController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public FieldController(IUnitOfWork unitOfWork, ILogger<FieldController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFields()
        {
            try
            {
                var fields = await _unitOfWork.Fields.GetAll();
                var results = _mapper.Map<List<FieldDTO>>(fields);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wronk un the {nameof(GetFields)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }

        }




        [HttpGet("{id:int}", Name = "GetFielde")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetField(int id)
        {
            try
            {
                var fieldy = await _unitOfWork.Fields.Get(q => q.Id_Field ==id);  // include  new List<string > {"Products" } opciono
                var result = _mapper.Map<FieldDTO>(fieldy);
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

        public async Task<IActionResult> CreateField([FromBody] FieldDTO fieldDTO)
        {
            if (!ModelState.IsValid)
            {

                _logger.LogError($"Invalid POST atempt in {nameof(CreateField)}");
                return BadRequest(ModelState);

            }

            try
            {
                var newfield = _mapper.Map<Field>(fieldDTO);
                await _unitOfWork.Fields.Insert(newfield);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetFielde", new { id = newfield.Id_Field }, newfield);   // [HttpGet("{id:int}", Name = "GetFielde")]

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreateField)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateField(int id, [FromBody] FieldDTO fieldDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE atempt in {nameof(UpdateField)}");
                return BadRequest(ModelState);
            }
            try
            {
                var fieldToUpdate = await _unitOfWork.Fields.Get(q => q.Id_Field == id);
               
                if (fieldToUpdate == null)
                {
                    _logger.LogError($"Invalid UPDATE atempt in {nameof(UpdateField)}"); //ime kontrolera
                    return BadRequest("Submitted data is invalid");

                }
                _mapper.Map(fieldDTO, fieldToUpdate);
                _unitOfWork.Fields.Update(fieldToUpdate);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdateField)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteField(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE atempt in {nameof(DeleteField)}");
                return BadRequest(ModelState);
            }
            try
            {
                var country = await _unitOfWork.Fields.Get(q => q.Id_Field == id);
                if (country == null)
                {
                    _logger.LogError($"Invalid DELETE atempt in {nameof(DeleteField)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Fields.Delete(id);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(DeleteField)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }


    }
}
