import axios from 'axios';
import {ECalculatorOperations, ECalculators, operationToApiIndex} from "./enum.ts";

export interface ICalculationOperation {
    number1: number;
    number2?: number;
    operation: ECalculatorOperations;
    calculator: ECalculators;
}

const instance = axios.create({
    baseURL: 'http://localhost:8085/api',
    timeout: 2000,
    withCredentials: false,
    headers: {
        "Content-Type": "application/json",
    },
});

export async function calculate(operation: ICalculationOperation) {
    console.log("Called calculate");

    try {
        // Convert operation to numeric index
        const data = {
            number1: operation.number1,
            number2: operation.number2,
            operation: operationToApiIndex(operation.operation), // Convert symbol to number
            calculator: operation.calculator, // Assuming your API accepts this as a string
        };

        console.log("======== Printing data from body ========");
        console.table(data);

        const response = await instance.post('/calculate', data);
        return response.data;
    } catch (error) {
        console.error("Error performing calculation:", error);
    }
}