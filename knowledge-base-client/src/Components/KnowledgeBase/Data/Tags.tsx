import { Tag } from "../../../Models";
import React from "react";
import { Controls, Signals, Containers } from "../../../Views";

interface Props {
    isSelected: (tag: Tag) => boolean;
    toggle: (tag: Tag) => void;
    tags: Tag[];
    isLoading: boolean;
}

export const Tags: React.FC<Props> = ({
    isSelected,
    toggle,
    tags,
    isLoading,
}) => {
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
