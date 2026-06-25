using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.DtoLayer.Dtos.ExperienceDtos;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly IExperienceService _ExperienceService;
        private readonly IMapper _mapper;

        public ExperiencesController(IExperienceService ExperienceService, IMapper mapper)
        {
            _ExperienceService = ExperienceService;
            _mapper = mapper;
        }

        [HttpGet("ExperienceList")]
        public async Task<IActionResult> ExperienceList()
        {
            var Experiences = await _ExperienceService.TGetListAsync();
            var ExperienceListDtos = _mapper.Map<List<ExperienceListDto>>(Experiences);
            return Ok(ExperienceListDtos);
        }

        [HttpGet("GetByIdExperience")]
        public async Task<IActionResult> GetByIdExperience(int id)
        {
            var GetExperiences = await _ExperienceService.TGetByIdAsync(id);
            return Ok(_mapper.Map<UpdateExperienceDto>(GetExperiences));
        }

        [HttpPut("ExperienceUpdate")]
        public async Task<IActionResult> ExperienceUpdate(UpdateExperienceDto ExperienceUpdateDto)
        {
            var validationResult = await _ExperienceService.ValidatorForUpdateExperienceOperationsAsync(ExperienceUpdateDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            
            await _ExperienceService.TUpdateAsync(_mapper.Map<Experience>(ExperienceUpdateDto));
            return Ok("Deneyim bilgisi güncellendi");
        }

        [HttpPost("ExperienceCreate")]
        public async Task<IActionResult> ExperienceCreate(CreateExperienceDto createExperienceDto)
        {
            var validationResult = await _ExperienceService.ValidatorForCreateExperienceOperationsAsync(createExperienceDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            await _ExperienceService.TInsertAsync(_mapper.Map<Experience>(createExperienceDto));
            return Ok("Deneyim bilgisi oluşturuldu");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedvalue = await _ExperienceService.TGetByIdAsync(id);
            if (deletedvalue != null)
            {
                await _ExperienceService.TDeleteAsync(deletedvalue);
                return Ok("Silme İşlemi Başarılı");
            }
            return NotFound("Hata: Kayıt bulunamadı.");
        }

        [HttpGet("ExperienceSection")]
        public async Task<IActionResult> GetExperienceProfileAsync()
        {
            var Experience = await _ExperienceService.TGetForExperienceSectionAsync();
            return Ok(Experience);
        }
    }
}

