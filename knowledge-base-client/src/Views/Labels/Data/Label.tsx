import { Typography } from "@material-ui/core";
import React from "react";
import { useSharedStyles } from "../../sharedStyles";

interface Props {
    title: string;
}

export const Label: React.FC<Props> = ({ title }) => {
    const { label } = useSharedStyles();

    return (
        <Typography
            className={label}
            variant="body2"
            style={{ alignSelf: "center" }}
        >
            {title}
        </Typography>
    );
};
