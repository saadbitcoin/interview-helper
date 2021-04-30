import React from "react";
import {
    Dialog as MaterialDialog,
    DialogContent,
    DialogTitle,
    IconButton,
    Toolbar,
} from "@material-ui/core";
import { Close } from "@material-ui/icons";

interface Props {
    isOpen: boolean;
    id: string;
    title: string;
    handleClose: () => void;
}

export const Dialog: React.FC<Props> = ({
    isOpen,
    children,
    id,
    title,
    handleClose,
}) => {
    return (
        <MaterialDialog
            open={isOpen}
            fullScreen={false}
            onClose={handleClose}
            aria-labelledby={id}
            fullWidth={true}
        >
            <Toolbar>
                <IconButton
                    edge="start"
                    color="primary"
                    onClick={handleClose}
                    aria-label="close"
                >
                    <Close />
                </IconButton>
            </Toolbar>

            <DialogTitle id={id}>{title}</DialogTitle>
            <DialogContent>{children}</DialogContent>
        </MaterialDialog>
    );
};
