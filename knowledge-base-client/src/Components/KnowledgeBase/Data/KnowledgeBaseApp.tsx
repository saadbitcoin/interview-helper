import React from "react";
import { Tags } from "./Tags";
import { DefaultContainer } from "../../../Views/Containers/Data/DefaultContainer";
import { Header } from "../../../Views/Labels/Data/Header";
import { useTagsSelect } from "../../../Hooks/Data/useTagsSelect";
import { QuestionRequestButtons } from "./QuestionRequestButtons";
import { useQuestions, useTags } from "../../../Hooks";
import { Questions } from "./Questions";

interface Props {}

export const KnowledgeBaseApp: React.FC<Props> = () => {
    const { endLoadingQuestions, isLoading, questions, startLoadingQuestions } =
        useQuestions();
    const { isSelected, selectedTagIds, toggle } = useTagsSelect();
    const { isLoading: tagsLoading, tags, addTag } = useTags();

    return (
        <div style={{ padding: "1rem" }}>
            <DefaultContainer>
                <Header title="База знаний" />
            </DefaultContainer>
            <Tags
                isSelected={isSelected}
                toggle={toggle}
                tags={tags}
                isLoading={tagsLoading}
            />
            <QuestionRequestButtons
                selectedIds={selectedTagIds}
                questionsAreLoading={isLoading}
                startLoadingQuestions={startLoadingQuestions}
                endLoadingQuestions={endLoadingQuestions}
                tags={tags}
                addTag={addTag}
            />
            <Questions questions={questions} isLoading={isLoading} />
        </div>
    );
};
