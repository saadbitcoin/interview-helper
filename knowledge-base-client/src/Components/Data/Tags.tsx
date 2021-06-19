import { Tag } from "../../Models";
import React from "react";
import { GridContainer } from "../../Views/Containers";
import { Loader } from "../../Views/Signals";
import { Checkbox } from "../../Views/Controls";

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
        <GridContainer>
            {tags.map((x) => (
                <Checkbox
                    key={x.id}
                    isSelected={isSelected(x)}
                    onClick={() => {
                        toggle(x);
                    }}
                    title={x.title}
                />
            ))}
        </GridContainer>
    );

    return (
        <>
            {isLoading && (
                <GridContainer>
                    <Loader />
                </GridContainer>
            )}
            {tagsView}
        </>
    );
};
