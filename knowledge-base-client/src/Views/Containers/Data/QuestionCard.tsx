import React from "react";
import { Card, Box, Chip } from "@material-ui/core";
import { Question } from "../../../Models";
import { useSharedStyles } from "../../sharedStyles";

interface Props {
    data: Question;
}

export const QuestionCard: React.FC<Props> = ({ data }) => {
    const { label, text } = useSharedStyles();
    const { answer, id, tags, title } = data;

    return (
        <Box width={1 / 3} m="1.5rem" padding="1rem">
            <Card square={true} variant="outlined">
                <h3 className={`${label} ${text}`}>
                    (#{id}) {title}{" "}
                </h3>
                {tags.map((x) => (
                    <Chip
                        label={x.title}
                        style={{ padding: "0.5rem", margin: "1rem" }}
                    />
                ))}
                <div
                    className={`${label}`}
                    style={{ padding: "0.5rem", margin: "1rem" }}
                >
                    {answer}
                </div>
            </Card>
        </Box>
    );
};
