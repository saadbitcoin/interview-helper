using AutoMapper;
using KnowledgeBase.WebAPI.Models;
using UseCases = KnowledgeBase.Domain.UseCases;
using Operations = KnowledgeBase.Domain.Operations;

namespace KnowledgeBase.WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateQuestionDTO, UseCases.CreateLinkedQuestionFromScratch.Request>()
                .ForMember(
                    destination => destination.Title,
                    x => x.MapFrom(source => source.Question)
                )
                .ForMember(
                    destination => destination.Tags,
                    x => x.MapFrom(source => source.AccordingTags)
                );

            CreateMap<UseCases.CreateLinkedQuestionFromScratch.Response, CreateQuestionResultDTO>()
                .ForMember(
                    destination => destination.QuestionId,
                    x => x.MapFrom(source => source.LinkedQuestionIdentifier)
                );

            CreateMap<CreateTagDTO, Operations.Tags.Create.Request>();

            CreateMap<Operations.Tags.GetAll.Response, GetTagsDTO>();
            CreateMap<UseCases.GetTaggedQuestionsByTagIds.Response, GetQuestionsDTO>();
        }
    }
}