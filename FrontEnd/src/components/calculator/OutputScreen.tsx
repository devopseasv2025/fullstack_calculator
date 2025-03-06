interface OutputScreenProps {
    value: string;
}

export default function OutputScreen ({ value }: OutputScreenProps) {

    return(
        <input type={"text"} readOnly disabled value={value}  data-testid={"result"}/>
    );
}