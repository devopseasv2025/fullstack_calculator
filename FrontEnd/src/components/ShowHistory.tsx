import { useState } from "react";
import { ICalculation} from "../model/ICalculation.ts";
import {gethistory} from "../apiV2.ts";

export default function ShowHistory() {
    const [calculations, setCalculations] = useState<ICalculation[]>([]);

    // Function to update history by calling the API
    const updateHistory = async () => {
        try {
            const history = await gethistory(); // Await the promise from gethistory()
            if (history) {
                setCalculations(history); // Update the state with the fetched data
            } else {
                console.error("No history data returned.");
            }
        } catch (error) {
            console.error("Error fetching history:", error);
        }
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
