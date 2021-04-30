import { Tag } from "../../Models";

class TagsAPIClient {
    public constructor(private endpoint: string) {}

    public async getAll() {
        const request = await fetch(`${this.endpoint}/Tags/all`);
        return request.json() as Promise<{ tags: Array<Tag> }>;
    }
}

const tagsAPIClient = new TagsAPIClient(
    process.env.REACT_APP_KNOWLEDGE_BASE_API_ENDPOINT!
);

export { tagsAPIClient };
