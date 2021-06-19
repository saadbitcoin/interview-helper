import { Box } from "@material-ui/core";
import React from "react";

interface Props {}

export const BoxContainer: React.FC<Props> = ({ children }) => {
    return (
        <Box style={{ paddingTop: "1rem", paddingBottom: "1rem" }}>
            {children}
        </Box>
    );
};
