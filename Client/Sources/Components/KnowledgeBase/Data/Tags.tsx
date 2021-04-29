import { useTags } from "Hooks";
import { Tag as TagModel } from "Models";
import React from "react";
import { globalState, useGlobalStateRerender } from "State";
import { Controls, Signals, Containers, Labels } from "Views";

interface TagProps {
    tag: TagModel;
}

const Tag: React.FC<TagProps> = ({ tag }) => {
    const indexOfSelectedTagId = globalState.selectedTagIds.indexOf(tag.id);

    const isSelected = indexOfSelectedTagId >= 0;
    const toggleSelectedTag = () => {
        if (isSelected) {
            globalState.selectedTagIds.splice(indexOfSelectedTagId, 1);
            return;
        }

        globalState.selectedTagIds.push(tag.id);
    };

    return (
        <Controls.Checkbox
            isSelected={isSelected}
            onClick={toggleSelectedTag}
            title={tag.title}
        />
    );
};

export const Tags: React.FC = () => {
    useGlobalStateRerender();
    const { isLoading } = useTags();

    if (isLoading) {
        return (
            <Containers.DefaultContainer>
                <Signals.Loader />
            </Containers.DefaultContainer>
        );
    }

    const header = (
        <Containers.DefaultContainer>
            <Labels.Subheader title="Доступные тэги" />
        </Containers.DefaultContainer>
    );

    const tags = (
        <Containers.DefaultContainer>
            {globalState.tags.map((x) => (
                <Tag tag={x} key={x.id} />
            ))}
        </Containers.DefaultContainer>
    );

    return (
        <>
            {header}
            {tags}
        </>
    );
};
