import { useFullTagInfo } from "Hooks";
import { TagBasicInfo } from "Models";
import React from "react";

interface Props {
    activeTag: TagBasicInfo | undefined;
    activeTagValues: Array<string>;
    setActiveTagValues: (target: Array<string>) => void;
}

export const CurrentTag: React.FC<Props> = ({
    activeTag,
    activeTagValues,
    setActiveTagValues
}) => {
    if (!activeTag) {
        return <h1>no active tag</h1>;
    }

    const { activeTagData, isLoading } = useFullTagInfo(activeTag.id);

    if (isLoading) {
        return <h1>loading</h1>;
    }

    return <h1>{JSON.stringify(activeTagData)}</h1>;
};
