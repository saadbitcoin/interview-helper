import { Question } from "../../Models";

class QuestionsAPIClient {
    public constructor(private endpoint: string) {}

    public async getByTags(tagIds: Array<number>) {
        const request = await fetch(
            `${this.endpoint}/questions/unionTagged/${tagIds.join(",")}`
        );
        return request.json() as Promise<Array<Question>>;
    }

    public async createNew(
        title: string,
        answer: string,
        tagIds: Array<number>
    ) {
        const request = await fetch(`${this.endpoint}/questions`, {
            method: "POST",
            body: JSON.stringify({
                title,
                answer,
                tagIds,
            }),
            headers: {
                "Content-Type": "application/json",
            },
        });
        return request.json() as Promise<any>;
    }
}

const questionsAPIClient = new QuestionsAPIClient(
    process.env.REACT_APP_KNOWLEDGE_BASE_API_ENDPOINT!
);

export { questionsAPIClient };
