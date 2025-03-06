import React from "react";

interface CalButtonProps {
    readonly text: string;
}

export function CalButton({ text }: CalButtonProps): React.ReactElement {
    return (
        <button data-testid={`button-${text}`}> { text } </button>
    );
}