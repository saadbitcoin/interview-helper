import { useState } from "react";
import { Tag } from "../../Models";

export function useTagsSelect() {
    const [selectedTagIds, setSelectedTagIds] = useState([] as Array<number>);

    const isSelected = (tag: Tag) => selectedTagIds.includes(tag.id);
    const toggle = (tag: Tag) => {
        if (isSelected(tag)) {
            setSelectedTagIds((x) => x.filter((y) => y !== tag.id));

            return;
        }

        setSelectedTagIds((x) => x.concat(tag.id));
    };

    return { selectedTagIds, isSelected, toggle };
}
