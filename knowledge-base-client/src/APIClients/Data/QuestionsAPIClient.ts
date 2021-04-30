import { Question } from "../../Models";

class QuestionsAPIClient {
    public constructor(private endpoint: string) {}

    public async getByTagsIntersection(tagIds: Array<number>) {
        const request = await fetch(
            `${this.endpoint}/questions/byTagsIntersection?${tagIds
                .map((x) => "tagIds=" + x)
                .join("&")}`
        );
        return request.json() as Promise<{ questions: Array<Question> }>;
    }

    public async getByTagsUnion(tagIds: Array<number>) {
        const request = await fetch(
            `${this.endpoint}/questions/byTagsUnion?${tagIds
                .map((x) => "tagIds=" + x)
                .join("&")}`
        );
        return request.json() as Promise<{ questions: Array<Question> }>;
    }
}

const questionsAPIClient = new QuestionsAPIClient(
    process.env.REACT_APP_KNOWLEDGE_BASE_API_ENDPOINT!
);

export { questionsAPIClient };
