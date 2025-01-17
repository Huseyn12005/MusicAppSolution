import api from "./api";

export const login = async (credentials) => {
    const response = await api.post("/identity/login", credentials);
    return response.data;
};