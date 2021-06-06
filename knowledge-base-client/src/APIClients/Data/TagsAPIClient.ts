import { Tag } from "../../Models";

class TagsAPIClient {
    public constructor(private endpoint: string) {}

    public async getAll() {
        const request = await fetch(`${this.endpoint}/Tags`);
        return request.json() as Promise<Array<Tag>>;
    }

    public async create(title: string) {
        const request = await fetch(`${this.endpoint}/tags`, {
            method: "POST",
            body: JSON.stringify({
                title,
            }),
            headers: {
                "Content-Type": "application/json",
            },
        });
        return request.json() as Promise<number>;
    }
}

const tagsAPIClient = new TagsAPIClient(
    process.env.REACT_APP_KNOWLEDGE_BASE_API_ENDPOINT!
);

export { tagsAPIClient };
