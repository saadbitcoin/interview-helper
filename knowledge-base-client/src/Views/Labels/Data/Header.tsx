import { Typography } from "@material-ui/core";
import React from "react";
import { useSharedStyles } from "../../sharedStyles";

interface Props {
    title: string;
}

export const Header: React.FC<Props> = ({ title }) => {
    const { label } = useSharedStyles();

    return (
        <Typography align={"left"} className={label} variant="h2">
            {title}
        </Typography>
    );
};
