import React, { useEffect } from "react";
import { render } from "react-dom";
import { KnowledgeBaseApp } from "Components";
import {
    knowledgeBaseQuestionsAPIClient,
    knowledgeBaseTagsAPIClient
} from "APIClients";

export const Index: React.FC = () => {
    useEffect(() => {
        knowledgeBaseQuestionsAPIClient.getById(4).then((x) => console.log(x));
        knowledgeBaseTagsAPIClient
            .getAllBasicInfo()
            .then((x) => console.log(JSON.stringify(x)));
    });
    return <KnowledgeBaseApp />;
};

render(<Index />, document.getElementById("root"));
