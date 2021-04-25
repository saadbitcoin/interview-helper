import { useQuestionsRequestData } from "Hooks";
import React from "react";
import { TagsOverview } from "./TagsOverview";
import { CurrentTag } from "./CurrentTag";

interface Props {}

export const KnowledgeBaseApp: React.FC<Props> = ({}) => {
    const {
        activeTag,
        activeTagValues,
        setActiveTag,
        setActiveTagValues
    } = useQuestionsRequestData();

    return (
        <>
            <TagsOverview activeTag={activeTag} setActiveTag={setActiveTag} />
            <CurrentTag
                activeTag={activeTag}
                activeTagValues={activeTagValues}
                setActiveTagValues={setActiveTagValues}
            />
        </>
    );
};
