import React from "react";
import { render } from "react-dom";
import { App } from "./Components";

export const Index: React.FC = () => {
    return <App />;
};

render(<Index />, document.getElementById("root"));
