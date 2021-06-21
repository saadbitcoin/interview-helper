import { FormControl } from "@material-ui/core";
import React from "react";

interface Props {}

export const FormControlContainer: React.FC<Props> = ({ children }) => {
    return (
        <FormControl fullWidth required style={{ margin: "15px 0px 15px 0px" }}>
            {children}
        </FormControl>
    );
};
