import { tagsAPIClient } from "../../APIClients";
import { Tag } from "../../Models";
import { useEffect, useState } from "react";

export function useTags() {
    const [isLoading, setIsLoading] = useState(true);
    const [tags, setTags] = useState([] as Array<Tag>);

    useEffect(() => {
        let isMounted = true;

        tagsAPIClient.getAll().then((x) => {
            if (isMounted) {
                setTags(x.tags);
                setIsLoading(false);
            }
        });

        return () => {
            isMounted = false;
        };
    }, []);

    return { isLoading, tags };
}
