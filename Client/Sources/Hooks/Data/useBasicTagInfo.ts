import { useEffect, useState } from "react";
import { knowledgeBaseTagsAPIClient } from "APIClients";
import { TagBasicInfo } from "Models";

export function useBasicTagInfo() {
    const [isLoading, setIsLoading] = useState(true);
    const [basicTagInfo, setBasicTagInfo] = useState<Array<TagBasicInfo>>([]);

    useEffect(() => {
        knowledgeBaseTagsAPIClient.getAllBasicInfo().then((tags) => {
            setBasicTagInfo(tags);
            setIsLoading(false);
        });
    }, []);

    return { basicTagInfo, isLoading };
}
