import { useEffect, useState } from "react";
import { knowledgeBaseTagsAPIClient } from "APIClients";
import { Tag } from "Models";

export function useFullTagInfo(activeTagId: number) {
    const [isLoading, setIsLoading] = useState(false);
    const [tagData, setTagData] = useState<Record<number, Tag>>({});

    useEffect(() => {
        if (!tagData[activeTagId]) {
            setIsLoading(true);
            knowledgeBaseTagsAPIClient.getById(activeTagId).then(({ data }) => {
                setTagData((x) => ({
                    ...x,
                    [activeTagId]: data
                }));

                setIsLoading(false);
            });
        }
    }, [activeTagId]);

    return { activeTagData: tagData[activeTagId], isLoading };
}
