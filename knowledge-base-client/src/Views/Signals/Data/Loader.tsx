import { CircularProgress } from "@material-ui/core";

import React from "react";

interface Props {}

export const Loader: React.FC<Props> = () => {
    return <CircularProgress style={{ padding: "1rem", margin: "1rem" }} />;
};
