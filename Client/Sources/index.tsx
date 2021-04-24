import React from "react";
import { render } from "react-dom";
import { KnowledgeBaseApp } from "Components";

export const Index: React.FC = () => {
    return <KnowledgeBaseApp />;
};

render(<Index />, document.getElementById("root"));
