import React from "react";
import { questionsAPIClient } from "../../APIClients";
import { Question } from "../../Models";
import { GridContainer } from "../../Views/Containers";
import { Button } from "../../Views/Controls";

interface Props {
    questionsAreLoading: boolean;
    startLoadingQuestions: () => void;
    endLoadingQuestions: (result: Array<Question>) => void;
    selectedIds: Array<number>;
    openTagCreationModal: () => void;
    openQuestionsCreationModal: () => void;
}

export const QuestionRequestButtons: React.FC<Props> = ({
    selectedIds,
    endLoadingQuestions,
    questionsAreLoading,
    startLoadingQuestions,
    openQuestionsCreationModal,
    openTagCreationModal,
}) => {
    return (
        <>
            <GridContainer>
                <Button
                    disabled={questionsAreLoading || selectedIds.length === 0}
                    title="Найти вопросы"
                    onClick={() => {
                        startLoadingQuestions();
                        questionsAPIClient
                            .getByTags(selectedIds)
                            .then(endLoadingQuestions);
                    }}
                />
                <Button
                    title="Добавить вопрос"
                    onClick={openQuestionsCreationModal}
                    type={"secondary"}
                    disabled={false}
                />
                <Button
                    title="Добавить тэг"
                    onClick={openTagCreationModal}
                    type={"secondary"}
                    disabled={false}
                />
            </GridContainer>
        </>
    );
};
