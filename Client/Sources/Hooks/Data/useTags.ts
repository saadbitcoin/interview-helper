import { globalState } from "State";
import { knowledgeBaseTagsAPIClient } from "APIClients";
import { useEffect, useState } from "react";

export function useTags() {
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        knowledgeBaseTagsAPIClient.getAll().then((x) => {
            globalState.tags = x.tags;
            setIsLoading(false);
        });
    }, []);

    return { isLoading };
}
