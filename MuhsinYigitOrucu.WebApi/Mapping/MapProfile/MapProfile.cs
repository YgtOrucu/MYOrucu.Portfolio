using AutoMapper;
using MuhsinYigitOrucu.DtoLayer.Dtos.AboutDtos;
using MuhsinYigitOrucu.DtoLayer.Dtos.ExperienceDtos;
using MuhsinYigitOrucu.DtoLayer.Dtos.MessageDto;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDetailsDto;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDtos;
using MuhsinYigitOrucu.DtoLayer.Dtos.SkillsDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ContactInfoSectionDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ExperienceSectionDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.FooterSectionDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.HeroSectionDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectDetailsSectionDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectSectionDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.SendMessageSectionDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.SkillsSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace Hotelier.WebAPI.Mapping.MapProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            /*ABOUT*/
            CreateMap<AboutListDto, About>().ReverseMap();
            CreateMap<AboutCreateDto, About>()
            .ForMember(dest => dest.TypewriterTitlesJson, opt => opt.Ignore())
            .ForMember(dest => dest.BioParagraphsJson, opt => opt.Ignore())
            .ForMember(dest => dest.QuickInfoJson, opt => opt.Ignore());
            CreateMap<AboutUpdateDto, About>().ReverseMap();
            CreateMap<GetForHeroSection, About>().ReverseMap();
            CreateMap<GetForHeroSection, GetForContactInfoSection>().ReverseMap();
            CreateMap<GetForHeroSection, GetForFooterSection>().ReverseMap();
            /*ABOUT*/

            /*EXPERIENCE*/
            CreateMap<ExperienceListDto, Experience>().ReverseMap();
            CreateMap<CreateExperienceDto, Experience>().ReverseMap();
            CreateMap<UpdateExperienceDto, Experience>().ReverseMap();
            CreateMap<GetForExperienceSectionDto, Experience>().ReverseMap();
            /*EXPERIENCE*/

            /*SKILLS*/
            CreateMap<SkillsListDto, Skills>().ReverseMap();
            CreateMap<CreateSkillsDto, Skills>().ReverseMap();
            CreateMap<UpdateSkillsDto, Skills>().ReverseMap();
            CreateMap<GetForSkillsSection, Skills>().ReverseMap();
            /*SKILLS*/


            /*PROJECT*/
            CreateMap<ProjectListDto, Project>().ReverseMap();
            CreateMap<CreateProjectDto, Project>()
            .ForMember(dest => dest.UseTechnologyJson, opt => opt.Ignore());

            CreateMap<UpdateProjectDto, Project>().ReverseMap();
            CreateMap<GetForProjectSection, Project>().ReverseMap();
            /*PROJECT*/


            /*PROJECT DETAİLS*/
            CreateMap<ProjectDetailsListDto, ProjectDetail>().ReverseMap();
            CreateMap<CreateProjectDetailsDto, ProjectDetail>()
            .ForMember(dest => dest.GalleryImagesJson, opt => opt.Ignore())
            .ForMember(dest => dest.UseTechnologyJson, opt => opt.Ignore())
            .ForMember(dest => dest.ChallengesJson, opt => opt.Ignore())
            .ForMember(dest => dest.FeaturesJson, opt => opt.Ignore());
            CreateMap<UpdateProjectDetailsDto, ProjectDetail>().ReverseMap().ForMember(dest => dest.DeleteGalleryImages, opt => opt.Ignore());

            CreateMap<GetForProjectDetailDto, ProjectDetail>().ReverseMap();
            /*PROJECT DETAİLS*/


            /*MESSAGE*/
            CreateMap<MessageListDto, Message>().ReverseMap();
            CreateMap<SendMessageDto, Message>().ReverseMap();
            /*MESSAGE*/
        }
    }
}
