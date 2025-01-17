import axios from "axios";

const api = axios.create({
    baseURL: "http://localhost:5001", // API Gateway URL
});

export default api;