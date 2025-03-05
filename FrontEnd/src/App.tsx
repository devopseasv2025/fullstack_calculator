import './App.css'
import SelectCal from "./SelectCal.tsx";
import { createContext, useState } from "react";

type CalculatorType = "simple" | "cached";

// Create the context with a default value
export const TypeOfCalContext = createContext<CalculatorType>("simple");

function App() {
    const [calType, setCalType] = useState<CalculatorType>("simple");

    return (
        <TypeOfCalContext.Provider value={calType}>
            <SelectCal setCalType={setCalType} />
        </TypeOfCalContext.Provider>
    );
}

export default App
