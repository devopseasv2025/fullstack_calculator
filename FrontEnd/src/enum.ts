export enum ECalculatorOperations {
    Addition = "+",
    Subtraction = "-",
    Multiplication = "*",
    Division = "/",
    Factorial = "!",
    Isprime = "p",
    empty = ""
}

export enum ECalculators {
    SimpleCalculator,
    CashedCalculator
}

//The below is not pretty and is a work-around due to my own laziness.
// Create a mapping for API indices
export const ECalculatorOperationsIndex = {
    "+": 0,
    "-": 1,
    "*": 2,
    "/": 3,
    "!": 4,
    "p": 5,
    "": 6
} as const;

// Reverse mapping for lookup
export const ECalculatorOperationsReverse: Record<number, ECalculatorOperations> = {
    0: ECalculatorOperations.Addition,
    1: ECalculatorOperations.Subtraction,
    2: ECalculatorOperations.Multiplication,
    3: ECalculatorOperations.Division,
    4: ECalculatorOperations.Factorial,
    5: ECalculatorOperations.Isprime,
    6: ECalculatorOperations.empty
};

// Convert enum to API index
export function operationToApiIndex(op: ECalculatorOperations): number {
    return ECalculatorOperationsIndex[op] ?? -1;
}

// Convert API index back to enum
export function apiIndexToOperation(index: number): ECalculatorOperations {
    return ECalculatorOperationsReverse[index] ?? ECalculatorOperations.empty;
}