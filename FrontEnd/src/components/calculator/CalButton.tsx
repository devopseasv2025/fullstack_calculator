import React from "react";

interface CalButtonProps {
    readonly text: string;
    readonly onClick: (text: string) => void;
}

export function CalButton({ text, onClick }: CalButtonProps): React.ReactElement {
    return (
        <button onClick={() => onClick(text)} id={`button-${text}`}>
            { text }
        </button>
    );
}