using System.Threading.Tasks;
using System.Collections.Generic;
using UseCase = KnowledgeBase.Domain.UseCases.CreateLinkedQuestionFromScratch;
using CreateQuestion = KnowledgeBase.Domain.Operations.Questions.Create;
using CreateTag = KnowledgeBase.Domain.Operations.Tags.Create;
using KnowledgeBase.Application.Services;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class CreateLinkedQuestionFromScratchHandler : UseCase.IHandler
    {
        private readonly CreateQuestion.IHandler _createQuestionCommand;
        private readonly CreateTag.IHandler _createTagCommand;
        private readonly IQuestionTagRelationshipManager _questionTagRelationshipManager;

        public CreateLinkedQuestionFromScratchHandler(CreateQuestion.IHandler createquestionCommand,
            CreateTag.IHandler createTagCommand, IQuestionTagRelationshipManager questionTagRelationshipManager)
        {
            _createQuestionCommand = createquestionCommand;
            _createTagCommand = createTagCommand;
            _questionTagRelationshipManager = questionTagRelationshipManager;
        }

        public async Task<UseCase.Response> Handle(UseCase.Request requestData)
        {
            var createQuestionRequest = new CreateQuestion.Request
            {
                Answer = requestData.Answer,
                Title = requestData.Title
            };
            var createQuestionResponse = await _createQuestionCommand.Handle(
                createQuestionRequest
            );
            if (!(createQuestionResponse.Success && createQuestionResponse.QuestionIdentifier.HasValue))
            {
                return new UseCase.Response { LinkedQuestionIdentifier = null, Success = false };
            }

            var tagIds = new List<int>();
            foreach (var tag in requestData.Tags)
            {
                var createTagRequest = new CreateTag.Request { Title = tag };
                var createTagResponse = await _createTagCommand.Handle(createTagRequest);
                if (createTagResponse.TagIdentifier.HasValue)
                {
                    tagIds.Add(createTagResponse.TagIdentifier.Value);
                }
            }

            await _questionTagRelationshipManager.LinkTagsToQuestion(
                createQuestionResponse.QuestionIdentifier.Value,
                tagIds.ToArray()
            );

            return new UseCase.Response
            {
                LinkedQuestionIdentifier = createQuestionResponse.QuestionIdentifier,
                Success = true
            };
        }
    }
}