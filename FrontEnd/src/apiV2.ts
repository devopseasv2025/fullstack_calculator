import axios from 'axios';
import {ECalculatorOperations, ECalculators} from "./enum.ts";

export interface ICalculationOperation {
    number1: number;
    number2?: number;
    operation: ECalculatorOperations;
    calculator: ECalculators;
}

const instance = axios.create({
    baseURL: 'http://localhost:8085/api',
    timeout: 2000,
    headers: {
        "Content-Type": "application/json",
    },
});

export async function calculate(operation: ICalculationOperation) {
    
    console.log("Called calculate")
    
    try {
        const data = JSON.stringify(operation)
        const response = await instance.post('/calculate', data);
        console.log(response);
        
    } catch (error) {
        console.error("Error performing calculation:", error);
    }
}



