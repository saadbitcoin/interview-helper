import { Tag, TagBasicInfo } from "Models";

class KnowledgeBaseTagsAPIClient {
    public constructor(private endpoint: string) {}

    public async getAllBasicInfo() {
        const request = await fetch(`${this.endpoint}/Tags/basicInfo`);
        return request.json() as Promise<Array<TagBasicInfo>>;
    }

    public async getById(id: number) {
        const request = await fetch(`${this.endpoint}/Tags/${id}`);
        return request.json() as Promise<{ data: Tag }>;
    }
}

const knowledgeBaseTagsAPIClient = new KnowledgeBaseTagsAPIClient(
    process.env.KNOWLEDGE_BASE_API_ENDPOINT!
);

export { knowledgeBaseTagsAPIClient };
