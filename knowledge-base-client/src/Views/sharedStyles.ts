import { createUseStyles } from "react-jss";

export const useSharedStyles = createUseStyles({
    label: {
        "-moz-user-select": "none",
        "-khtml-user-select": "none",
        "-webkit-user-select": "none",
        "-ms-user-select": "none",
        "user-select": "none",
        padding: "0.5rem",
    },
    text: {
        padding: "1rem",
        textAlign: "center",
    },
});
