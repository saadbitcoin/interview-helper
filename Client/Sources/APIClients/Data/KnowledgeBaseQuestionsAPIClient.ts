// import { KnowledgeBaseQuestion } from "Models";

// class KnowledgeBaseQuestionsAPIClient {
//     public constructor(private endpoint: string) {}

//     public async getById(id: number) {
//         const request = await fetch(`${this.endpoint}/Questions/${id}`);
//         return request.json() as Promise<KnowledgeBaseQuestion | null>;
//     }

//     public async add(model: {
//         question: string;
//         answer: string;
//         tags: Record<string, Array<string>>;
//     }) {
//         const request = await fetch(`${this.endpoint}/Questions`, {
//             method: "POST",
//             body: JSON.stringify(model)
//         });

//         return request.json() as Promise<{ questionIdentifier: number }>;
//     }

//     public async getByLinkedTags(tag: string, values: string[]) {
//         const request = await fetch(
//             `${this.endpoint}/Questions/byLinkedTags/${tag}`,
//             {
//                 method: "GET",
//                 headers: { "x-tag-values": values.join(",") }
//             }
//         );

//         return request.json() as Promise<Array<KnowledgeBaseQuestion>>;
//     }
// }

// const knowledgeBaseQuestionsAPIClient = new KnowledgeBaseQuestionsAPIClient(
//     process.env.KNOWLEDGE_BASE_API_ENDPOINT!
// );

// export { knowledgeBaseQuestionsAPIClient };
