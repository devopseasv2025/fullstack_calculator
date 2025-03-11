import http from 'k6/http';
import { sleep, check } from 'k6';
import { Shardarray } from 'k6/data';
import {ECalculators} from "./enum.js";

var url = 'http://localhost:8080/api/calculate'

export const options = {
    stages: [
        { duration: '30s', target: 2000 },
        { duration: '1m', target: 2000 },
        { duration: '30s', target: 0 },
    ]
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

const randomOperator = (enumeration) => {
    const values = Object.keys(enumeration);
    const enumKey = values[Math.floor(Math.random() * values.length)];
    return enumeration[enumKey];
}

const payload = JSON.stringify({
    Number1: getRandomInt(1, 100),
    Number2: getRandomInt(1, 100) ,
    Operation: randomOperator(ECalculators),
    Result: 0,
    Calculator: randomOperator(ECalculators)
});

export default () => {
    const response = http.post(url, payload, {
        headers: {'Content-Type': 'application/json'}
    });
    check(response, {'200': (r => r.status === 200)});
    sleep(1);
}