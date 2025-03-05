import {CalButton} from "./CalButton.tsx";
import OutputScreen from "./OutputScreen.tsx";

export function Calculator () {

    return (
        <div className={"calculator"}>
            <OutputScreen/>
            <div className={"button-row"}>
                <CalButton text={"Clear"}/>
                <CalButton text={"Delete"}/>
                <CalButton text={","}/>
                <CalButton text={"/"}/>
            </div>
            <div className={"button-row"}>
                <CalButton text={"7"}/>
                <CalButton text={"8"}/>
                <CalButton text={"9"}/>
                <CalButton text={"*"}/>
            </div>
            <div className={"button-row"}>
                <CalButton text={"4"}/>
                <CalButton text={"5"}/>
                <CalButton text={"6"}/>
                <CalButton text={"-"}/>
            </div>
            <div className={"button-row"}>
                <CalButton text={"1"}/>
                <CalButton text={"2"}/>
                <CalButton text={"3"}/>
                <CalButton text={"+"}/>
            </div>
            <div className={"button-row"}>
                <CalButton text={"0"}/>
                <CalButton text={"="}/>
            </div>
        </div>
    );
}