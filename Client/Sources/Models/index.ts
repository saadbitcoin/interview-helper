export type Tag = {
    id: number;
    title: string;
};

export type Question = {
    id: number;
    title: string;
    answer: string;
    tags: Array<Tag>;
};
