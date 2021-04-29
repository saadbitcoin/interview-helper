import { Tag } from "Models";

class KnowledgeBaseTagsAPIClient {
    public constructor(private endpoint: string) {}

    public async getAll() {
        const request = await fetch(`${this.endpoint}/Tags/all`);
        return request.json() as Promise<{ tags: Array<Tag> }>;
    }
}

const knowledgeBaseTagsAPIClient = new KnowledgeBaseTagsAPIClient(
    process.env.KNOWLEDGE_BASE_API_ENDPOINT!
);

export { knowledgeBaseTagsAPIClient };
