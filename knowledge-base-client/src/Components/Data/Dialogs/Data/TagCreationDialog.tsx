import { TextField } from "@material-ui/core";
import React, { useState } from "react";
import { tagsAPIClient } from "../../../../APIClients";
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
    addTag: (tag: Tag) => void;
}

export const TagCreationDialog: React.FC<Props> = ({
    closeModal,
    isOpen,
    addTag,
}) => {
    const [newTagTitle, setNewTagTitle] = useState("");

    return (
        <Dialog
            id="create-tag"
            handleClose={closeModal}
            isOpen={isOpen}
            title={"Добавление тэга"}
        >
            <FormControlContainer>
                <TextField
                    label={"Название"}
                    value={newTagTitle}
                    onChange={(e) => setNewTagTitle(e.target.value)}
                />
            </FormControlContainer>
            <BoxContainer>
                <Button
                    onClick={() => {
                        tagsAPIClient.create(newTagTitle).then((id) => {
                            addTag({ title: newTagTitle, id });
                            setNewTagTitle("");
                            closeModal();
                        });
                    }}
                    title={"Добавить"}
                />
            </BoxContainer>
        </Dialog>
    );
};
