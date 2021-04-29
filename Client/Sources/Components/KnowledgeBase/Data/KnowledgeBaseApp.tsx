import React from "react";
import { Tags } from "./Tags";
import { Labels, Containers } from "Views";

interface Props {}

export const KnowledgeBaseApp: React.FC<Props> = ({}) => {
    return (
        <>
            <Containers.DefaultContainer>
                <Labels.Header title="База знаний" />
            </Containers.DefaultContainer>
            <Tags />
        </>
    );
};
