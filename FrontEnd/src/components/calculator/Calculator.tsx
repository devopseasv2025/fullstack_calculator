import {CalButton} from "./CalButton.tsx";
import OutputScreen from "./OutputScreen.tsx";
import React from "react";

export function Calculator () {

    const [operator, setOperator] = React.useState<string>("");
    const [operand1, setOperand1] = React.useState<string>("");
    const [operand2, setOperand2] = React.useState<string>("");

    const handleClick = (text: string) => {
        if (text === "Clear") {
            setOperator("");
            setOperand1("");
            setOperand2("");
        }  else if (text === "Delete") {
            if (operand2) {
                setOperand2(operand2.slice(0, -1));
            } else if (operator) {
                setOperator("");
            } else {
                setOperand1(operand1.slice(0, -1));
            }
        } else if (["+", "-", "*", "/"].includes(text)) {
            if (operand1 && !operator) setOperator(text);
        } else if (text === "=") {
            if (operand1 && operator && operand2) {
                console.log("API CALL HERE")
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