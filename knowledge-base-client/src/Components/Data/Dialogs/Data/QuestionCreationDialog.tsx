import { TextareaAutosize, TextField } from "@material-ui/core";
import { Autocomplete } from "@material-ui/lab";
import React, { useState } from "react";
import { questionsAPIClient } from "../../../../APIClients";
import { Tag } from "../../../../Models";
import {
    BoxContainer,
    Dialog,
    FormControlContainer,
} from "../../../../Views/Containers";
import { Button } from "../../../../Views/Controls";

interface Props {
    closeModal: () => void;
    isOpen: boolean;
    tags: Array<Tag>;
}

export const QuestionCreationDialog: React.FC<Props> = ({
    closeModal,
    isOpen,
    tags,
}) => {
    const [newQuestionData, setNewQuestionData] = useState({
        title: "",
        answer: "",
        tags: [] as Array<Tag>,
    });

    return (
        <Dialog
            id="create-question"
            handleClose={closeModal}
            isOpen={isOpen}
            title={"Добавление вопроса"}
        >
            <FormControlContainer>
                <TextField
                    label={"Вопрос"}
                    value={newQuestionData.title}
                    onChange={(e) =>
                        setNewQuestionData((x) => ({
                            ...x,
                            title: e.target.value,
                        }))
                    }
                />
            </FormControlContainer>
            <FormControlContainer>
                <TextareaAutosize
                    placeholder="Ответ"
                    value={newQuestionData.answer}
                    onChange={(e) =>
                        setNewQuestionData((x) => ({
                            ...x,
                            answer: e.target.value,
                        }))
                    }
                    style={{ fontSize: 16, minHeight: "100px" }}
                />
            </FormControlContainer>
            <FormControlContainer>
                <Autocomplete
                    multiple
                    id="select-ids"
                    options={tags}
                    getOptionLabel={(option) => option.title}
                    value={newQuestionData.tags}
                    renderInput={(params) => (
                        <TextField
                            {...params}
                            variant="standard"
                            label="Тэги вопроса"
                            placeholder="Выберите тэги"
                        />
                    )}
                    onChange={(e, value) => {
                        setNewQuestionData((x) => ({
                            ...x,
                            tags: value,
                        }));
                    }}
                />
            </FormControlContainer>
            <BoxContainer>
                <Button
                    disabled={
                        !newQuestionData.answer ||
                        !newQuestionData.title ||
                        !newQuestionData.tags.length
                    }
                    onClick={() => {
                        questionsAPIClient
                            .createNew(
                                newQuestionData.title,
                                newQuestionData.answer,
                                newQuestionData.tags.map((x) => x.id)
                            )
                            .then((x) => {
                                setNewQuestionData({
                                    answer: "",
                                    title: "",
                                    tags: [],
                                });
                                closeModal();
                            });
                    }}
                    title={"Добавить"}
                />
            </BoxContainer>
        </Dialog>
    );
};
