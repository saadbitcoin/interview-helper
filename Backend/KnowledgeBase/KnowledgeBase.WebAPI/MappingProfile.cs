using AutoMapper;
using KnowledgeBase.WebAPI.Models;
using AddQuestionUseCase = KnowledgeBase.Domain.UseCaseContracts.AddQuestion;
using ObtainQuestionByIdentifierUseCase = KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionByIdentifier;

namespace KnowledgeBase.WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddQuestionDTO, AddQuestionUseCase.Request>()
                .ForMember(
                    destination => destination.Answer,
                    x => x.MapFrom(src => src.Answer)
                )
                .ForMember(
                    destination => destination.Title,
                    x => x.MapFrom(src => src.Question)
                )
                .ForMember(
                    destination => destination.InitialTags,
                    x => x.MapFrom(x => x.Tags)
                );

            CreateMap<AddQuestionUseCase.Response, AddQuestionResultDTO>()
                .ForMember(
                    destination => destination.QuestionIdentifier,
                    x => x.MapFrom(src => src.QuestionId)
                );

            CreateMap<int, ObtainQuestionByIdentifierUseCase.Request>()
                .ForMember(
                    destination => destination.QuestionIdentifier,
                    x => x.MapFrom(src => src)
                );
        }
    }
}