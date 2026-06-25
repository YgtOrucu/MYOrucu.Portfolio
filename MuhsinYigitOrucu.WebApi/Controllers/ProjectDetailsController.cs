using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDetailsDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectDetailsController : ControllerBase
    {
        private readonly IProjectDetailsService _projectDetailService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public ProjectDetailsController(IProjectDetailsService projectDetailService, IMapper mapper, IFileService fileService)
        {
            _projectDetailService = projectDetailService;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet("ProjectDetailList")]
        public async Task<IActionResult> ProjectDetailList()
        {
            var details = await _projectDetailService.TGetListAsync();
            var detailListDtos = _mapper.Map<List<ProjectDetailsListDto>>(details);
            return Ok(detailListDtos);
        }

        [HttpGet("GetByIdProjectDetail")]
        public async Task<IActionResult> GetByIdProjectDetail(int id)
        {
            var detail = await _projectDetailService.TGetByIdAsync(id);
            if (detail == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }
            return Ok(_mapper.Map<UpdateProjectDetailsDto>(detail));
        }

        [HttpGet("ProjectSectionDetail/{Id}")]
        public async Task<IActionResult> GetProjectProfileAsync(int Id)
        {
            var Project = await _projectDetailService.TGetForProjectDetailsSectionAsync(Id);
            return Ok(Project);
        }

        [HttpPut("ProjectDetailUpdate")]
        public async Task<IActionResult> ProjectDetailUpdate(UpdateProjectDetailsDto projectDetailUpdateDto)
        {
            var validationResult = await _projectDetailService.ValidatorForUpdateProjectDetailOperationsAsync(projectDetailUpdateDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            if (projectDetailUpdateDto.CoverImageFile != null)
            {
                if (!string.IsNullOrEmpty(projectDetailUpdateDto.CoverImageUrl))
                {
                    await _fileService.DeleteOldImage(projectDetailUpdateDto.CoverImageUrl);
                }
                projectDetailUpdateDto.CoverImageUrl = await _fileService.UploadImageAsync(projectDetailUpdateDto.CoverImageFile, "ProjectDetailsImages");
            }

            if (projectDetailUpdateDto.DeleteGalleryImages != null && projectDetailUpdateDto.DeleteGalleryImages.Any())
            {
                foreach (var oldImg in projectDetailUpdateDto.DeleteGalleryImages)
                {
                    if (!string.IsNullOrEmpty(oldImg))
                        await _fileService.DeleteOldImage(oldImg);
                }
            }

            if (projectDetailUpdateDto.GalleryImageFile != null && projectDetailUpdateDto.GalleryImageFile.Any())
            {
                projectDetailUpdateDto.GalleryImages ??= new List<string>();

                foreach (var file in projectDetailUpdateDto.GalleryImageFile)
                {
                    var uploadedPath = await _fileService.UploadImageAsync(file, "ProjectDetailsImages");
                    projectDetailUpdateDto.GalleryImages.Add(uploadedPath);
                }
            }
            await _projectDetailService.TUpdateAsync(_mapper.Map<ProjectDetail>(projectDetailUpdateDto));
            return Ok("Proje detay bilgisi güncellendi");
        }

        [HttpPost("ProjectDetailCreate")]
        public async Task<IActionResult> ProjectDetailCreate(CreateProjectDetailsDto projectDetailCreateDto)
        {
            var validationResult = await _projectDetailService.ValidatorForCreateProjectDetailOperationsAsync(projectDetailCreateDto);
            var existingDetail = await _projectDetailService.TAnyProjectDetailByProjectIdAsync(projectDetailCreateDto.ProjectId);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            if (existingDetail)
            {
                return BadRequest(new List<string> { "Bu projeye ait detay bilgisi zaten mevcut." });
            }

            projectDetailCreateDto.CoverImageUrl = await _fileService.UploadImageAsync(projectDetailCreateDto.CoverImageFile!, "ProjectDetailsImages");

            projectDetailCreateDto.GalleryImages = new List<string>();
            if (projectDetailCreateDto.GalleryImageFile != null && projectDetailCreateDto.GalleryImageFile.Any())
            {
                foreach (var file in projectDetailCreateDto.GalleryImageFile)
                {
                    var uploadedPath = await _fileService.UploadImageAsync(file, "ProjectDetailsImages");
                    projectDetailCreateDto.GalleryImages.Add(uploadedPath);
                }
            }
            await _projectDetailService.TInsertAsync(_mapper.Map<ProjectDetail>(projectDetailCreateDto));
            return Ok("Proje detay bilgisi oluşturuldu");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedValue = await _projectDetailService.TGetByIdAsync(id);
            if (deletedValue != null)
            {
                if (!string.IsNullOrEmpty(deletedValue.CoverImageUrl))
                {
                    await _fileService.DeleteOldImage(deletedValue.CoverImageUrl);
                }

                if (deletedValue.GalleryImages != null && deletedValue.GalleryImages.Any())
                {
                    foreach (var imgPath in deletedValue.GalleryImages)
                    {
                        if (!string.IsNullOrEmpty(imgPath))
                        {
                            await _fileService.DeleteOldImage(imgPath);
                        }
                    }
                }
                await _projectDetailService.TDeleteAsync(deletedValue);

                return Ok("Silme İşlemi Başarılı");
            }
            return NotFound("Hata: Kayıt bulunamadı.");
        }

        [HttpGet("GetProjectNameWithDetailsPage")]
        public async Task<IActionResult> GetProjectNameWithDetailsPage()
        {
            var Project = await _projectDetailService.TGetProjectNameWithDetailsPage();
            return Ok(Project);
        }
    }
}