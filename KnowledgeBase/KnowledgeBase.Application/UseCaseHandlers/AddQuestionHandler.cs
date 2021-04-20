using SharedKernel;
using KnowledgeBase.Domain.UseCaseContracts.AddQuestion;
using System.Threading.Tasks;
using KnowledgeBase.Application.Repositories;
using KnowledgeBase.Domain;
using System.Collections.Generic;

namespace KnowledgeBase.Application.UseCaseHandlers
{
    public class AddQuestionHandler : UseCaseHandler<Request, Response>
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly ITagsRepository _tagsRepository;
        private readonly ILinkedTagsRepository _linkedTagsRepository;

        public AddQuestionHandler(IQuestionsRepository questionsRepository, ITagsRepository tagsRepository,
            ILinkedTagsRepository linkedTagsRepository)
        {
            _questionsRepository = questionsRepository;
            _tagsRepository = tagsRepository;
            _linkedTagsRepository = linkedTagsRepository;
        }

        public async Task<Response> Handle(Request requestData)
        {
            var linkedTags = new List<LinkedTag>();
            var tagTitles = requestData.InitialTags.Keys;

            foreach (var tagTitle in tagTitles)
            {
                var tag = await _tagsRepository.GetTag(tagTitle);

                if (tag == null)
                {
                    tag = new Tag { Title = tagTitle };
                    await _tagsRepository.AddTag(tag);
                }

                var tagValue = requestData.InitialTags[tagTitle];

                var linkedTag = await _linkedTagsRepository.GetLinkedTag(tagTitle, tagValue);

                if (linkedTag == null)
                {
                    linkedTag = new LinkedTag { Tag = tag, Value = tagValue };
                    var newLinkedTagId = await _linkedTagsRepository.AddLinkedTag(linkedTag);
                }

                linkedTags.Add(linkedTag);
            }

            var newQuestion = new Question
            {
                Answer = requestData.Answer,
                LinkedTags = linkedTags.ToArray(),
                Title = requestData.Title
            };

            var newQuestionId = await _questionsRepository.AddQuestion(newQuestion);

            return new Response { QuestionId = newQuestionId };
        }
    }
}