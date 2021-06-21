import React, { useState } from "react";
import { Tags } from "./Tags";
import {
    GridContainer,
    MainApplicationContrainer,
} from "../../Views/Containers";
import { Header } from "../../Views/Labels/Data/Header";
import { useTagsSelect } from "../../Hooks/Data/useTagsSelect";
import { QuestionRequestButtons } from "./QuestionRequestButtons";
import { useQuestions, useTags } from "../../Hooks";
import { Questions } from "./Questions";
import { QuestionCreationDialog, TagCreationDialog } from "./Dialogs";

interface Props {}

export const App: React.FC<Props> = () => {
    const { endLoadingQuestions, isLoading, questions, startLoadingQuestions } =
        useQuestions();
    const { isSelected, selectedTagIds, toggle } = useTagsSelect();
    const { isLoading: tagsLoading, tags, addTag } = useTags();
    const [isOpenedCreationModal, setIsOpenedCreationModal] = useState(false);
    const [isOpenedNewTagModal, setIsOpenedNewTagModal] = useState(false);

    const openQuestionsCreationModal = () => setIsOpenedCreationModal(true);
    const openTagCreationModal = () => setIsOpenedNewTagModal(true);
    const closeQuestionCreationModel = () => setIsOpenedCreationModal(false);
    const closeTagCreationDialog = () => setIsOpenedNewTagModal(false);

    return (
        <MainApplicationContrainer>
            <GridContainer>
                <Header title="База знаний" />
            </GridContainer>
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
                openQuestionsCreationModal={openQuestionsCreationModal}
                openTagCreationModal={openTagCreationModal}
            />
            <QuestionCreationDialog
                closeModal={closeQuestionCreationModel}
                isOpen={isOpenedCreationModal}
                tags={tags}
            />
            <TagCreationDialog
                addTag={addTag}
                closeModal={closeTagCreationDialog}
                isOpen={isOpenedNewTagModal}
            />
            <Questions questions={questions} isLoading={isLoading} />
        </MainApplicationContrainer>
    );
};
