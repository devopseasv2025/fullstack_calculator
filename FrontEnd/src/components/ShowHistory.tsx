import { useState } from "react";
import { ICalculation} from "../model/ICalculation.ts";

export default function ShowHistory() {
    const [calculations, setCalculations] = useState<ICalculation[]>([]);

    // Function to update history by calling the API
    const updateHistory = () => {
        fetch("https://api.example.com/calculations")
            .then((response) => response.json())
            .then((data: ICalculation[]) => setCalculations(data))
            .catch((error) => console.error("Error fetching data:", error));
    };

    return (
        <div>
            <h3>History</h3>
            <button data-testid={"refreshHistory"} onClick={updateHistory}>Refresh History</button>
            {calculations.length === 0 ? (
                <p>No history available.</p>
            ) : (
                calculations.map((calc, index) => (
                    <div key={index}>
                        <p>"
                            {calc.number1} {calc.operation} {calc.number2 ?? ""} = {calc.result}
                        </p>
                    </div>
                ))
            )}
        </div>
    );
}
