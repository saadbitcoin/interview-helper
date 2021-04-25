import React, { useEffect } from "react";
import { render } from "react-dom";
import { KnowledgeBaseApp } from "Components";
import { knowledgeBaseAPIClient } from "APIClients/Data/KnowledgeBaseAPIClient";

export const Index: React.FC = () => {
    useEffect(() => {
        knowledgeBaseAPIClient.getById(4).then((x) => console.log(x));
    });
    return <KnowledgeBaseApp />;
};

render(<Index />, document.getElementById("root"));
