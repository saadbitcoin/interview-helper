import React, { useState } from "react";
import { questionsAPIClient } from "../../../APIClients";
import { Question } from "../../../Models";
import { DefaultContainer } from "../../../Views/Containers";
import { Button } from "../../../Views/Controls";

interface Props {
    questionsAreLoading: boolean;
    startLoadingQuestions: () => void;
    endLoadingQuestions: (result: Array<Question>) => void;
    selectedIds: Array<number>;
}

export const QuestionRequestButtons: React.FC<Props> = ({
    selectedIds,
    endLoadingQuestions,
    questionsAreLoading,
    startLoadingQuestions,
}) => {
    return (
        <DefaultContainer>
            <Button
                disabled={questionsAreLoading || selectedIds.length === 0}
                title="Найти вопросы по объединению тэгов"
                onClick={() => {
                    startLoadingQuestions();
                    questionsAPIClient.getByTagsUnion(selectedIds).then((x) => {
                        endLoadingQuestions(x.questions);
                    });
                }}
            />
            <Button
                disabled={questionsAreLoading || selectedIds.length === 0}
                title="Найти вопросы по пересечению тэгов"
                onClick={() => {
                    startLoadingQuestions();
                    questionsAPIClient
                        .getByTagsIntersection(selectedIds)
                        .then((x) => {
                            endLoadingQuestions(x.questions);
                        });
                }}
            />
        </DefaultContainer>
    );
};
