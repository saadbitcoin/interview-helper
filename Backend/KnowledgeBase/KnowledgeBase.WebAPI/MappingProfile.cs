using AutoMapper;
using KnowledgeBase.WebAPI.Models;
using AddQuestionUseCase = KnowledgeBase.Domain.UseCaseContracts.AddQuestion;
using ObtainQuestionByIdentifierUseCase = KnowledgeBase.Domain.UseCaseContracts.ObtainQuestionByIdentifier;
using LinkNewTagToQuestionUseCase = KnowledgeBase.Domain.UseCaseContracts.LinkNewTagToQuestion;

namespace KnowledgeBase.WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddQuestionDTO, AddQuestionUseCase.Request>()
                .ForMember(
                    destination => destination.Answer,
                    x => x.MapFrom(source => source.Answer)
                )
                .ForMember(
                    destination => destination.Title,
                    x => x.MapFrom(source => source.Question)
                )
                .ForMember(
                    destination => destination.InitialTags,
                    x => x.MapFrom(source => source.Tags)
                );

            CreateMap<AddQuestionUseCase.Response, AddQuestionResultDTO>()
                .ForMember(
                    destination => destination.QuestionIdentifier,
                    x => x.MapFrom(source => source.QuestionId)
                );

            CreateMap<int, ObtainQuestionByIdentifierUseCase.Request>()
                .ForMember(
                    destination => destination.QuestionIdentifier,
                    x => x.MapFrom(source => source)
                );

            CreateMap<LinkNewTagToQuestionUseCase.Response, LinkTagsResultDTO>()
                .ForMember(
                    destination => destination.LinkedTagsCount,
                    x => x.MapFrom(source => source.TotalLinkedTagsCount)
                );
        }
    }
}