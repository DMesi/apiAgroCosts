using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StorageServiceLibrary.DTO;
using StorageServiceLibrary.IRepository;
using StorageServiceLibrary.Model;

namespace apiAC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<PlanController> _logger;

        public CategoryController(IUnitOfWork unitOfWork, ILogger<PlanController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategory()
        {
            try
            {
                var categories = await _unitOfWork.Categorys.GetAll();
                var results = _mapper.Map<List<CategoryDTO>>(categories);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wronk un the {nameof(GetCategory)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }

        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> category(int id)
        {
            try
            {
                var cate = await _unitOfWork.Categorys.customQuery(q => q.Id_Category == id);

                var result = _mapper.Map<List<CategoryDTO>>(cate);

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

        public async Task<IActionResult> CreateCate([FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {

                _logger.LogError($"Invalid POST atempt in {nameof(CreateCate)}");
                return BadRequest(ModelState);

            }

            try
            {
                var newCategory = _mapper.Map<Category>(categoryDTO);
                await _unitOfWork.Categorys.Insert(newCategory);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetCategory", new { id = newCategory.Id_Category }, newCategory);   // da bi ovo radilo prikazalo novo kreiranu lokaciju moramo dodati  [HttpGet("{id:int}", Name = "GetLocation")]

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreateCate)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCate(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE atempt in {nameof(UpdateCate)}");
                return BadRequest(ModelState);
            }
            try
            {
                var category = await _unitOfWork.Categorys.Get(q => q.Id_Category == id);
                if (category == null)
                {
                    _logger.LogError($"Invalid UPDATE atempt in {nameof(UpdateCate)}"); //ime kontrolera
                    return BadRequest("Submitted data is invalid");

                }
                _mapper.Map(categoryDTO, category);
                _unitOfWork.Categorys.Update(category);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdateCate)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCate(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE atempt in {nameof(DeleteCate)}");
                return BadRequest(ModelState);
            }
            try
            {
                var plan = await _unitOfWork.Categorys.Get(q => q.Id_Category == id);
                if (plan == null)
                {
                    _logger.LogError($"Invalid DELETE atempt in {nameof(DeleteCate)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Categorys.Delete(id);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(DeleteCate)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }


    }
}
