import './App.css'
import SelectCal from "./components/SelectCal.tsx";
import {createContext, useState} from "react";
import {Calculator} from "./components/calculator/Calculator.tsx";
import ShowHistory from "./components/ShowHistory.tsx";
import {ECalculators} from "./enum.ts";


// Create the context with a default value
export const TypeOfCalContext = createContext<ECalculators>(ECalculators.CashedCalculator);

function App() {
    const [calType, setCalType] = useState<ECalculators>(ECalculators.SimpleCalculator);

    return (
        <TypeOfCalContext.Provider value={calType}>
            <SelectCal setCalType={setCalType} />
            <Calculator/>
            <ShowHistory />
        </TypeOfCalContext.Provider>
    );
}

export default App
