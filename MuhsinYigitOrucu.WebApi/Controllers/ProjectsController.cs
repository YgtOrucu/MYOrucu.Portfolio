using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDtos;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _ProjectService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public ProjectsController(IProjectService ProjectService, IMapper mapper, IFileService fileService)
        {
            _ProjectService = ProjectService;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet("ProjectList")]
        public async Task<IActionResult> ProjectList()
        {
            var Projects = await _ProjectService.TGetListAsync();
            var ProjectListDtos = _mapper.Map<List<ProjectListDto>>(Projects);
            return Ok(ProjectListDtos);
        }

        [HttpGet("GetByIdProject")]
        public async Task<IActionResult> GetByIdProject(int id)
        {
            var GetProjects = await _ProjectService.TGetByIdAsync(id);
            return Ok(_mapper.Map<UpdateProjectDto>(GetProjects));
        }

        [HttpPut("ProjectUpdate")]
        public async Task<IActionResult> ProjectUpdate(UpdateProjectDto ProjectUpdateDto)
        {
            var validationResult = await _ProjectService.ValidatorForUpdateProjectOperationsAsync(ProjectUpdateDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            if (ProjectUpdateDto.FormFile != null)
            {
                await _fileService.DeleteOldImage(ProjectUpdateDto.ImageUrl!);
                ProjectUpdateDto.ImageUrl = await _fileService.UploadImageAsync(ProjectUpdateDto.FormFile, "ProjectImages");
            }
            await _ProjectService.TUpdateAsync(_mapper.Map<Project>(ProjectUpdateDto));
            return Ok("Hakkında bilgisi güncellendi");
        }

        [HttpPost("ProjectCreate")]
        public async Task<IActionResult> ProjectCreate(CreateProjectDto ProjectCreateDto)
        {
            var validationResult = await _ProjectService.ValidatorForCreateProjectOperationsAsync(ProjectCreateDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            ProjectCreateDto.ImageUrl = await _fileService.UploadImageAsync(ProjectCreateDto.FormFile!, "ProjectImages");
            await _ProjectService.TInsertAsync(_mapper.Map<Project>(ProjectCreateDto));
            return Ok("Hakkında bilgisi oluşturuldu");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedvalue = await _ProjectService.TGetByIdAsync(id);
            if (deletedvalue != null)
            {
                await _fileService.DeleteOldImage(deletedvalue.ImageUrl!);
                await _ProjectService.TDeleteAsync(deletedvalue);
                return Ok("Silme İşlemi Başarılı");
            }
            return NotFound("Hata: Kayıt bulunamadı.");
        }

        [HttpGet("ProjectSection")]
        public async Task<IActionResult> GetProjectProfileAsync()
        {
            var Project = await _ProjectService.TGetForProjectSectionAsync();
            return Ok(Project);
        }
    }
}
