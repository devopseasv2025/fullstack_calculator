import {CalButton} from "./CalButton.tsx";
import OutputScreen from "./OutputScreen.tsx";
import {ECalculatorOperations} from "../../enum.ts";
import React, {useContext} from "react";
import {calculate, ICalculationOperation} from "../../apiV2.ts";
import {TypeOfCalContext} from "../../App.tsx";

export function Calculator () {
    const calType = useContext(TypeOfCalContext);


    const [operator, setOperator] = React.useState<ECalculatorOperations>(ECalculatorOperations.empty);
    const [operand1, setOperand1] = React.useState<string>("");
    const [operand2, setOperand2] = React.useState<string>("");

    const handleClick = async (text: string) => {
        if (text === "Clear") {
            setOperator(ECalculatorOperations.empty);
            setOperand1("");
            setOperand2("");
        } else if (text === "Delete") {
            if (operand2) {
                setOperand2(operand2.slice(0, -1));
            } else if (operator) {
                setOperator(ECalculatorOperations.empty);
            } else {
                setOperand1(operand1.slice(0, -1));
            }
        } else if (["+", "-", "*", "/"].includes(text)) {
            if (operand1 && !operator) {
                // Map the button symbol to the enum value
                switch (text) {
                    case "+":
                        setOperator(ECalculatorOperations.Addition);
                        break;
                    case "-":
                        setOperator(ECalculatorOperations.Subtraction);
                        break;
                    case "*":
                        setOperator(ECalculatorOperations.Multiplication);
                        break;
                    case "/":
                        setOperator(ECalculatorOperations.Division);
                        break;
                    default:
                        break;
                }
            }
        } else if (text === "=") {
            if (operand1 && operator && operand2) {
                const operation: ICalculationOperation = {
                    number1: parseFloat(operand1),
                    number2: parseFloat(operand2),
                    operation: operator,
                    calculator: calType, // Assuming 1 is for SimpleCalculator, you can change this as per your requirement
                };

                const calculationResult = await calculate(operation);
                
                console.log(calculationResult);
                
                if (calculationResult != null) {
                    setOperand1(calculationResult.result);
                    setOperand2("");
                    setOperator(ECalculatorOperations.empty);

                    console.log(calculationResult.result);
                }
            }
        } else {
            if (!operator) {
                setOperand1(operand1 + text);
            } else {
                setOperand2(operand2 + text);
            }
        }
    };

    return (
        <div className={"calculator"}>
            <OutputScreen value={`${operand1} ${operator} ${operand2}`}/>
            <div className={"button-row"}>
                <CalButton text={"Clear"} onClick={handleClick} />
                <CalButton text={"Delete"} onClick={handleClick} />
                <CalButton text={"/"} onClick={handleClick} />
            </div>
            <div className={"button-row"}>
                <CalButton text={"7"} onClick={handleClick} />
                <CalButton text={"8"} onClick={handleClick} />
                <CalButton text={"9"} onClick={handleClick} />
                <CalButton text={"*"} onClick={handleClick} />
            </div>
            <div className={"button-row"}>
                <CalButton text={"4"} onClick={handleClick} />
                <CalButton text={"5"} onClick={handleClick} />
                <CalButton text={"6"} onClick={handleClick} />
                <CalButton text={"-"} onClick={handleClick} />
            </div>
            <div className={"button-row"}>
                <CalButton text={"1"} onClick={handleClick} />
                <CalButton text={"2"} onClick={handleClick} />
                <CalButton text={"3"} onClick={handleClick} />
                <CalButton text={"+"} onClick={handleClick} />
            </div>
            <div className={"button-row"}>
                <CalButton text={"0"} onClick={handleClick} />
                <CalButton text={"="} onClick={handleClick} />
            </div>
        </div>
    );
}