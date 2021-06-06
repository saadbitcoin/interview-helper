import { tagsAPIClient } from "../../APIClients";
import { Tag } from "../../Models";
import { useEffect, useState } from "react";

export function useTags() {
    const [isLoading, setIsLoading] = useState(true);
    const [tags, setTags] = useState([] as Array<Tag>);

    const addTag = (tag: Tag) => setTags((x) => [...x, tag]);

    useEffect(() => {
        let isMounted = true;

        tagsAPIClient.getAll().then((x) => {
            if (isMounted) {
                setTags(x);
                setIsLoading(false);
            }
        });

        return () => {
            isMounted = false;
        };
    }, []);

    return { isLoading, tags, addTag };
}
