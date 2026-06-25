using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.DtoLayer.Dtos.SkillsDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService _SkillsService;
        private readonly IMapper _mapper;

        public SkillsController(ISkillsService SkillsService, IMapper mapper)
        {
            _SkillsService = SkillsService;
            _mapper = mapper;
        }

        [HttpGet("SkillsList")]
        public async Task<IActionResult> SkillsList()
        {
            var Skillss = await _SkillsService.TGetListAsync();
            var SkillsListDtos = _mapper.Map<List<SkillsListDto>>(Skillss);
            return Ok(SkillsListDtos);
        }

        [HttpGet("GetByIdSkills")]
        public async Task<IActionResult> GetByIdSkills(int id)
        {
            var GetSkillss = await _SkillsService.TGetByIdAsync(id);
            return Ok(_mapper.Map<UpdateSkillsDto>(GetSkillss));
        }

        [HttpPut("SkillsUpdate")]
        public async Task<IActionResult> SkillsUpdate(UpdateSkillsDto SkillsUpdateDto)
        {
            var validationResult = await _SkillsService.ValidatorForUpdateSkillsOperationsAsync(SkillsUpdateDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            await _SkillsService.TUpdateAsync(_mapper.Map<Skills>(SkillsUpdateDto));
            return Ok("Deneyim bilgisi güncellendi");
        }

        [HttpPost("SkillsCreate")]
        public async Task<IActionResult> SkillsCreate(CreateSkillsDto createSkillsDto)
        {
            var validationResult = await _SkillsService.ValidatorForCreateSkillsOperationsAsync(createSkillsDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            await _SkillsService.TInsertAsync(_mapper.Map<Skills>(createSkillsDto));
            return Ok("Deneyim bilgisi oluşturuldu");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedvalue = await _SkillsService.TGetByIdAsync(id);
            if (deletedvalue != null)
            {
                await _SkillsService.TDeleteAsync(deletedvalue);
                return Ok("Silme İşlemi Başarılı");
            }
            return NotFound("Hata: Kayıt bulunamadı.");
        }

        [HttpGet("SkillsSection")]
        public async Task<IActionResult> GetSkillsProfileAsync()
        {
            var Skills = await _SkillsService.TGetForSkillsSectionAsync();
            return Ok(Skills);
        }
    }
}
