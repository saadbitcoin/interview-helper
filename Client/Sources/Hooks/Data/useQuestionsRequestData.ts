import { TagBasicInfo } from "Models";
import { useState } from "react";

export function useQuestionsRequestData() {
    const [activeTag, setActiveTag] = useState<TagBasicInfo | undefined>(
        undefined
    );
    const [activeTagValues, setActiveTagValues] = useState<Array<string>>([]);

    return {
        activeTag,
        activeTagValues,
        setActiveTag,
        setActiveTagValues
    };
}
