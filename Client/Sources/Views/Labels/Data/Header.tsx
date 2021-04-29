import React from "react";
import { useSharedStyles } from "Views/sharedStyles";

interface Props {
    title: string;
}

export const Header: React.FC<Props> = ({ title }) => {
    const { label } = useSharedStyles();

    return <h1 className={label}>{title}</h1>;
};
