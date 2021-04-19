using AutoMapper;
using KnowledgeBase.Domain;
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
                    destination => destination.Data,
                    x => x.MapFrom(src => new Question { Answer = src.Answer, Title = src.Question })
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