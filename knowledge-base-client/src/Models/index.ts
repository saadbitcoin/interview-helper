type QuestionData = {
    id: number;
    title: string;
    answer: string;
};

export type Tag = {
    id: number;
    title: string;
};

export type Question = {
    question: QuestionData;
    tags: Array<Tag>;
};
