import { useContext } from "react";
import { TypeOfCalContext } from "../App.tsx";

interface SelectCalProps {
    setCalType: (type: "simple" | "cached") => void;
}

export default function SelectCal({ setCalType }: Readonly <SelectCalProps>) {
    const calType = useContext(TypeOfCalContext);

    return (
        <div>
            <h1>SELECT A CALCULATOR</h1>
            <h5 style={{ backgroundColor: "tomato" }}> EASV Calculator only works with integers</h5>
            <p>Current selection: {calType}</p>
            <button data-testid={"buttonSimple"} onClick={() => setCalType("simple")}>Simple Calculator</button>
            <button data-testid={"buttonCached"} onClick={() => setCalType("cached")}>Cached Calculator</button>
        </div>
    );
}
