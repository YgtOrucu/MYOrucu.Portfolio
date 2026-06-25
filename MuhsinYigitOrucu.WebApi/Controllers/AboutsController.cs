using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.DtoLayer.Dtos.AboutDtos;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public AboutsController(IAboutService aboutService, IMapper mapper, IFileService fileService)
        {
            _aboutService = aboutService;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet("AboutList")]
        public async Task<IActionResult> AboutList()
        {
            var abouts = await _aboutService.TGetListAsync();
            var aboutListDtos = _mapper.Map<List<AboutListDto>>(abouts);
            return Ok(aboutListDtos);
        }

        [HttpGet("GetByIdAbout")]
        public async Task<IActionResult> GetByIdAbout(int id)
        {
            var Getabouts = await _aboutService.TGetByIdAsync(id);
            return Ok(_mapper.Map<AboutUpdateDto>(Getabouts));
        }

        [HttpPut("AboutUpdate")]
        public async Task<IActionResult> AboutUpdate(AboutUpdateDto aboutUpdateDto)
        {
            var validationResult = await _aboutService.ValidatorForUpdateAboutOperationsAsync(aboutUpdateDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            if (aboutUpdateDto.FormFile != null)
            {
                await _fileService.DeleteOldImage(aboutUpdateDto.AvatarUrl);
                aboutUpdateDto.AvatarUrl = await _fileService.UploadImageAsync(aboutUpdateDto.FormFile, "AboutImages");
            }
            await _aboutService.TUpdateAsync(_mapper.Map<About>(aboutUpdateDto));
            return Ok("Hakkında bilgisi güncellendi");
        }

        [HttpPost("AboutCreate")]
        public async Task<IActionResult> AboutCreate(AboutCreateDto aboutCreateDto)
        {
            var validationResult = await _aboutService.ValidatorForCreateAboutOperationsAsync(aboutCreateDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            aboutCreateDto.AvatarUrl = await _fileService.UploadImageAsync(aboutCreateDto.FormFile, "AboutImages");
            await _aboutService.TInsertAsync(_mapper.Map<About>(aboutCreateDto));
            return Ok("Hakkında bilgisi oluşturuldu");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedvalue = await _aboutService.TGetByIdAsync(id);
            if (deletedvalue != null)
            {
                await _fileService.DeleteOldImage(deletedvalue.AvatarUrl);
                await _aboutService.TDeleteAsync(deletedvalue);
                return Ok("Silme İşlemi Başarılı");
            }
            return NotFound("Hata: Kayıt bulunamadı.");
        }

        [HttpGet("HeroSection")]
        public async Task<IActionResult> GetHeroProfileAsync()
        {
            var hero = await _aboutService.TGetForHeroSectionAsync();
            return Ok(hero);
        }

        [HttpGet("AboutSection")]
        public async Task<IActionResult> GetAboutProfileAsync()
        {
            var about = await _aboutService.TGetForAboutSectionAsync();
            return Ok(about);
        }
    }
}
