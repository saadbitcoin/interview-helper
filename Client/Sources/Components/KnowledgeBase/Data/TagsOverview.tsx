import React from "react";
import { useBasicTagInfo } from "Hooks";
import { TagBasicInfo } from "Models";

interface Props {
    setActiveTag: (target: TagBasicInfo) => void;
    activeTag: TagBasicInfo | undefined;
}

export const TagsOverview: React.FC<Props> = ({ setActiveTag }) => {
    const { isLoading, basicTagInfo } = useBasicTagInfo();

    if (isLoading) {
        return <h1>LOADING</h1>;
    }

    return (
        <>
            {basicTagInfo.map((x) => (
                <h3 onClick={() => setActiveTag(x)}>{JSON.stringify(x)}</h3>
            ))}
        </>
    );
};
