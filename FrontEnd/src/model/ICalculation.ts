import {ECalculatorOperations} from "../enum.ts";

export interface ICalculation {
    number1: number;
    number2?: number;
    operation: ECalculatorOperations;
    result: number;
}