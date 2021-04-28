import { useTags } from "Hooks";
import React from "react";

interface Props {}

export const Tags: React.FC<Props> = ({}) => {
    const { tags, isLoading } = useTags();

    if (isLoading) {
        return <h1>loading</h1>;
    }

    return <h1>{JSON.stringify(tags)}</h1>;
};
