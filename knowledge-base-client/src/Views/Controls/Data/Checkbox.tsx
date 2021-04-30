import React from "react";
import {
    Checkbox as MaterialCheckbox,
    FormControlLabel,
    Grid,
} from "@material-ui/core";
import { useSharedStyles } from "../../../Views/sharedStyles";
import { createUseStyles } from "react-jss";

interface Props {
    title: string;
    onClick: () => void;
    isSelected: boolean;
}

const useStyles = createUseStyles({
    checkbox: {
        "&:hover": {
            "background-color": "#ffe6e6",
        },
    },
});

export const Checkbox: React.FC<Props> = ({ isSelected, onClick, title }) => {
    const { label } = useSharedStyles();
    const { checkbox } = useStyles();
    return (
        <Grid item className={label + " " + checkbox}>
            <FormControlLabel
                control={
                    <MaterialCheckbox
                        checked={isSelected}
                        onClick={onClick}
                        title={title}
                    />
                }
                label={title}
                labelPlacement="end"
            />
        </Grid>
    );
};
