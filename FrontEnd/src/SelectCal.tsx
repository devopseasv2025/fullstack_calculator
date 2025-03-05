import { useContext, useEffect } from "react";
import { TypeOfCalContext } from "./App";

interface SelectCalProps {
    setCalType: (type: "simple" | "cached") => void;
}

export default function SelectCal({ setCalType }: SelectCalProps) {
    const calType = useContext(TypeOfCalContext);

    // Debug: Print the current type whenever it changes
    useEffect(() => {
        console.log("Current calculator type:", calType);
    }, [calType]);

    return (
        <div>
            <h1>SELECT A CALCULATOR</h1>
            <p>Current selection: {calType}</p>
            <button onClick={() => setCalType("simple")}>Simple Calculator</button>
            <button onClick={() => setCalType("cached")}>Cached Calculator</button>
        </div>
    );
}
