import { useTags } from "../../../Hooks";
import { Tag } from "../../../Models";
import React from "react";
import { Controls, Signals, Containers, Labels } from "../../../Views";

interface Props {
    isSelected: (tag: Tag) => boolean;
    toggle: (tag: Tag) => void;
}

export const Tags: React.FC<Props> = ({ isSelected, toggle }) => {
    const { isLoading, tags } = useTags();

    const tagsView = (
        <Containers.DefaultContainer>
            {tags.map((x) => (
                <Controls.Checkbox
                    key={x.id}
                    isSelected={isSelected(x)}
                    onClick={() => {
                        toggle(x);
                    }}
                    title={x.title}
                />
            ))}
        </Containers.DefaultContainer>
    );

    return (
        <>
            {isLoading && (
                <Containers.DefaultContainer>
                    <Signals.Loader />
                </Containers.DefaultContainer>
            )}
            {tagsView}
        </>
    );
};
