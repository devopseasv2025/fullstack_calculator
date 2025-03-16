import {ECalculatorOperations, ECalculators} from "./enum.ts";

const API_URL = "http://localhost:8085/api"; // import.meta.env.VITE_API_URL || 

export interface ICalculationOperation {
    number1: number;
    number2?: number;
    operation: ECalculatorOperations;
    calculator: ECalculators;
}

export async function fetchCalculations(){
    try {
        const response = await fetch(`${API_URL}`);
        if (!response.ok) {
            throw new Error("Failed to fetch calculations");
        }
        return await response.json();
    } catch (error) {
        console.error("Error fetching data:", error);
        return [];
    }
}
export async function calculate(operation: ICalculationOperation) {
    try {

        console.log("API_URL:", API_URL);

        const response = await fetch(`${API_URL}/calculate`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(operation),
        });

        if (!response.ok) {
            throw new Error("Failed to fetch calculation result");
        }

        return await response.json();
    } catch (error) {
        console.error("Error:", error);
        return null;
    }
}
