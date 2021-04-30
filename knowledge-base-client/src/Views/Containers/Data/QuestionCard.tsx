import React from "react";
import { Card, Box, Chip, Typography } from "@material-ui/core";
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
                <Typography className={`${label} ${text}`} variant="subtitle1">
                    (#{id}) {title}
                </Typography>

                {tags.map((x) => (
                    <Chip
                        label={x.title}
                        className={label}
                        style={{ padding: "0.5rem", margin: "1rem" }}
                    />
                ))}
                <Typography
                    className={`${label}`}
                    style={{ padding: "0.5rem", margin: "1rem" }}
                    variant="body1"
                >
                    {answer}
                </Typography>
            </Card>
        </Box>
    );
};
