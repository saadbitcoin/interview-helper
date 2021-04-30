import { Typography } from "@material-ui/core";
import React from "react";
import { useSharedStyles } from "../../sharedStyles";

interface Props {
    title: string;
}

export const Subheader: React.FC<Props> = ({ title }) => {
    const { label } = useSharedStyles();

    return (
        <Typography className={label} variant="h4">
            {title}
        </Typography>
    );
};
