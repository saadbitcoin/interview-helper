import { KnowledgeBaseQuestion } from "Models";

class KnowledgeBaseAPIClient {
    public constructor(private endpoint: string) {}

    public async getById(id: number): Promise<KnowledgeBaseQuestion | null> {
        const request = await fetch(`${this.endpoint}/Questions/${id}`);
        return request.json() as Promise<KnowledgeBaseQuestion | null>;
    }
}

const knowledgeBaseAPIClient = new KnowledgeBaseAPIClient(
    process.env.KNOWLEDGE_BASE_API_ENDPOINT!
);

export { knowledgeBaseAPIClient };
