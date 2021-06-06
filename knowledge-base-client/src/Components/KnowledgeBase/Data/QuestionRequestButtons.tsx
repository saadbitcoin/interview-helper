import {
    Box,
    FormControl,
    TextField,
    TextareaAutosize,
} from "@material-ui/core";
import { Autocomplete } from "@material-ui/lab";
import React, { useState } from "react";
import { questionsAPIClient, tagsAPIClient } from "../../../APIClients";
import { Question, Tag } from "../../../Models";
import { DefaultContainer, Dialog } from "../../../Views/Containers";
import { Button } from "../../../Views/Controls";

interface Props {
    questionsAreLoading: boolean;
    startLoadingQuestions: () => void;
    endLoadingQuestions: (result: Array<Question>) => void;
    selectedIds: Array<number>;
    tags: Array<Tag>;
    addTag: (tag: Tag) => void;
}

// ! DECOUPLE INTO DIFFIRENT COMPONENTS AND REFACTOR
export const QuestionRequestButtons: React.FC<Props> = ({
    selectedIds,
    endLoadingQuestions,
    questionsAreLoading,
    startLoadingQuestions,
    tags,
    addTag,
}) => {
    const [isOpenedCreationModal, setIsOpenedCreationModal] = useState(false);
    const [isOpenedNewTagModal, setIsOpenedNewTagModal] = useState(false);

    const [newQuestionData, setNewQuestionData] = useState({
        title: "",
        answer: "",
        tags: [] as Array<Tag>,
    });
    const [newTagTitle, setNewTagTitle] = useState("");

    return (
        <>
            <DefaultContainer>
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
                    onClick={() => {
                        setIsOpenedCreationModal(true);
                    }}
                    type={"secondary"}
                    disabled={false}
                />
                <Button
                    title="Добавить тэг"
                    onClick={() => {
                        setIsOpenedNewTagModal(true);
                    }}
                    type={"secondary"}
                    disabled={false}
                />
            </DefaultContainer>
            <Dialog
                id="create-question"
                handleClose={() => setIsOpenedCreationModal(false)}
                isOpen={isOpenedCreationModal}
                title={"Добавление вопроса"}
            >
                <FormControl fullWidth required>
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
                </FormControl>
                <FormControl fullWidth required style={{ marginTop: "15px" }}>
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
                </FormControl>
                <FormControl
                    fullWidth
                    required
                    style={{ marginBottom: "15px" }}
                >
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
                </FormControl>
                <Box style={{ paddingTop: "1rem", paddingBottom: "1rem" }}>
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
                                    setIsOpenedCreationModal(false);
                                });
                        }}
                        title={"Добавить"}
                    />
                </Box>
            </Dialog>

            <Dialog
                id="create-tag"
                handleClose={() => setIsOpenedNewTagModal(false)}
                isOpen={isOpenedNewTagModal}
                title={"Добавление тэга"}
            >
                <FormControl fullWidth required>
                    <TextField
                        label={"Название"}
                        value={newTagTitle}
                        onChange={(e) => setNewTagTitle(e.target.value)}
                    />
                </FormControl>
                <Box style={{ paddingTop: "1rem", paddingBottom: "1rem" }}>
                    <Button
                        disabled={false}
                        onClick={() => {
                            tagsAPIClient.create(newTagTitle).then((id) => {
                                addTag({ title: newTagTitle, id });
                                setNewTagTitle("");
                                setIsOpenedNewTagModal(false);
                            });
                        }}
                        title={"Добавить"}
                    />
                </Box>
            </Dialog>
        </>
    );
};
