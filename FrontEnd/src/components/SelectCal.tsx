import { useContext } from "react";
import { TypeOfCalContext } from "../App.tsx";
import { ECalculators } from "../enum.ts";

interface SelectCalProps {
    setCalType: (type: ECalculators) => void; // Use the ECalculators enum type here
}

export default function SelectCal({ setCalType }: Readonly<SelectCalProps>) {
    const calType = useContext(TypeOfCalContext);

    return (
        <div>
            <h1>SELECT A CALCULATOR</h1>
            <h5 style={{ backgroundColor: "tomato" }}>EASV Calculator only works with integers</h5>
            <p>Current selection: {calType}</p>
            <button
                id={"buttonSimple"}
                onClick={() => setCalType(ECalculators.SimpleCalculator)} // Use the enum value here
            >
                Simple Calculator
            </button>
            <button
                id={"buttonCached"}
                onClick={() => setCalType(ECalculators.CashedCalculator)} // Use the enum value here
            >
                Cached Calculator
            </button>
        </div>
    );
}
