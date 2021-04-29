import { CircularProgress } from "@material-ui/core";

import React from "react";

interface Props {}

export const Loader: React.FC<Props> = ({}) => {
    return <CircularProgress />;
};
