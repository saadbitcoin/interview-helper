import React from "react";
import { Button as MaterialButton, Grid } from "@material-ui/core";

interface Props {
    title: string;
    onClick: () => void;
    disabled: boolean;
}

export const Button: React.FC<Props> = ({ onClick, title, disabled }) => {
    return (
        <Grid item>
            <MaterialButton
                onClick={onClick}
                variant="contained"
                color="primary"
                disabled={disabled}
            >
                {title}
            </MaterialButton>
        </Grid>
    );
};
