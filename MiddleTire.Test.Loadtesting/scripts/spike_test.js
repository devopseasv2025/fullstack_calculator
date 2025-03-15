import http from 'k6/http';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '10s', target: 100 }, 
        { duration: '1m', target: 100 }, 
        { duration: '10s', target: 1400 }, 
        { duration: '3m', target: 1400 }, 
        { duration: '10s', target: 100 }, 
        { duration: '3m', target: 100 }, 
        { duration: '10s', target: 0 }, 
    ],
    
    thresholds: {
        http_req_failed: ['rate<0.001'], // http errors should be less than 0.1%
        http_req_duration: ['p(95)<500'], // 95 percent of response times must be below 500ms
    },
    
};

export default () => {

    const data = {
        "number1": 1,
        "number2": 0,
        "operation": 0,
        "result": 0,
        "calculator": 0
    }

    const url = `http://localhost:8085/api/calculate`;

    http.post(url, JSON.stringify(data), {
        headers: { 'Content-Type': 'application/json' },
    });
}; 