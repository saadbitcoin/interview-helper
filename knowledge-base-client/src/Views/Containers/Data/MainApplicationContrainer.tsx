import React from "react";

interface Props {}

export const MainApplicationContrainer: React.FC<Props> = ({ children }) => {
    return <div style={{ padding: "1rem" }}>{children}</div>;
};
