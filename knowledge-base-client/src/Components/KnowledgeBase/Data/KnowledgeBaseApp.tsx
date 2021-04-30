import React, { useState } from "react";
import { Tags } from "./Tags";
import { DefaultContainer } from "../../../Views/Containers/Data/DefaultContainer";
import { Header } from "../../../Views/Labels/Data/Header";
import { useTagsSelect } from "../../../Hooks/Data/useTagsSelect";
import { Question } from "../../../Models";
import { QuestionRequestButtons } from "./QuestionRequestButtons";
import { useQuestions } from "../../../Hooks";
import { Questions } from "./Questions";

interface Props {}

export const KnowledgeBaseApp: React.FC<Props> = () => {
    const {
        endLoadingQuestions,
        isLoading,
        questions,
        startLoadingQuestions,
    } = useQuestions();
    const { isSelected, selectedTagIds, toggle } = useTagsSelect();

    return (
        <>
            <DefaultContainer>
                <Header title="База знаний" />
            </DefaultContainer>
            <Tags isSelected={isSelected} toggle={toggle} />
            <QuestionRequestButtons
                selectedIds={selectedTagIds}
                questionsAreLoading={isLoading}
                startLoadingQuestions={startLoadingQuestions}
                endLoadingQuestions={endLoadingQuestions}
            />
            <Questions questions={questions} isLoading={isLoading} />
        </>
    );
};
