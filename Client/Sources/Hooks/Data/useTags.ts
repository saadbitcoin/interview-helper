import { Tag } from "Models";
import { knowledgeBaseTagsAPIClient } from "APIClients";
import { useEffect, useState } from "react";

export function useTags() {
    const [tags, setTags] = useState<Tag[]>([]);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        knowledgeBaseTagsAPIClient.getAll().then((x) => {
            setTags(x);
            setIsLoading(false);
        });
    }, []);

    return { tags, isLoading };
}
