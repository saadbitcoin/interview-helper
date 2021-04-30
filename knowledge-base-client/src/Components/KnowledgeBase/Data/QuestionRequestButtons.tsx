import { Box, FormControl, TextField } from "@material-ui/core";
import React, { useState } from "react";
import { questionsAPIClient } from "../../../APIClients";
import { Question } from "../../../Models";
import { DefaultContainer, Dialog } from "../../../Views/Containers";
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
    const [isOpenedCreationModal, setIsOpenedCreationModal] = useState(false);

    return (
        <>
            <DefaultContainer>
                <Button
                    disabled={questionsAreLoading || selectedIds.length === 0}
                    title="Найти вопросы по объединению тэгов"
                    onClick={() => {
                        startLoadingQuestions();
                        questionsAPIClient
                            .getByTagsUnion(selectedIds)
                            .then((x) => {
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
                <Button
                    title="Загрузить новый вопрос"
                    onClick={() => {
                        setIsOpenedCreationModal(true);
                    }}
                    type={"secondary"}
                    disabled={false}
                />
            </DefaultContainer>
            <Dialog
                id="create-question"
                handleClose={() => setIsOpenedCreationModal(false)}
                isOpen={isOpenedCreationModal}
                title={"Загрузка вопроса"}
            >
                <FormControl fullWidth required>
                    <TextField label={"Вопрос"} />
                </FormControl>
                <FormControl fullWidth required>
                    <TextField label={"Ответ"} />
                </FormControl>
                <FormControl fullWidth required>
                    <TextField label={"Тэги через запятую"} />
                </FormControl>
                <Box style={{ paddingTop: "1rem", paddingBottom: "1rem" }}>
                    <Button
                        disabled={false}
                        onClick={() => {}}
                        title={"Загрузить новый вопрос"}
                    />
                </Box>
            </Dialog>
        </>
    );
};
