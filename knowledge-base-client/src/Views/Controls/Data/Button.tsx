import React from "react";
import { Button as MaterialButton, Grid } from "@material-ui/core";

interface Props {
    title: string;
    onClick: () => void;
    disabled: boolean;
    type?: "primary" | "secondary";
}

export const Button: React.FC<Props> = ({
    onClick,
    title,
    disabled,
    type = "primary",
}) => {
    return (
        <Grid item>
            <MaterialButton
                onClick={onClick}
                variant="contained"
                color={type}
                disabled={disabled}
            >
                {title}
            </MaterialButton>
        </Grid>
    );
};
