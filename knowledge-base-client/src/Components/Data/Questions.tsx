import React from "react";
import { Question } from "../../Models";
import { GridContainer, QuestionCard } from "../../Views/Containers";
import { Loader } from "../../Views/Signals";

interface Props {
    questions: Array<Question>;
    isLoading: boolean;
}

export const Questions: React.FC<Props> = ({ questions, isLoading }) => {
    if (isLoading) {
        return <Loader />;
    }

    return (
        <GridContainer>
            {questions.map((x) => (
                <QuestionCard data={x} />
            ))}
        </GridContainer>
    );
};
