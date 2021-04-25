export type KnowledgeBaseQuestion = {
    id: number;
    title: string;
    answer: string;
    tagsInformation: Record<string, string[]>;
};
