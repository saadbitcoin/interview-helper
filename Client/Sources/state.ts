import { Tag } from "Models";
import { buildRevar } from "revars";

export const [globalState, useGlobalStateRerender] = buildRevar({
    tags: [] as Array<Tag>,
    selectedTagIds: [] as Array<number>
});
