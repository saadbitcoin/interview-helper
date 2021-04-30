import { useState } from "react";
import { Question } from "../../Models";

export function useQuestions() {
    const [questions, setQuestions] = useState([] as Array<Question>);
    const [isLoading, setIsLoading] = useState(false);

    return {
        questions,
        isLoading,
        startLoadingQuestions: () => setIsLoading(true),
        endLoadingQuestions: (result: Array<Question>) => {
            setQuestions(result);
            setIsLoading(false);
        },
    };
}
