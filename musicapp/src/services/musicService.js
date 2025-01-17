import api from "./api";

export const getMusic = async () => {
    const response = await api.get("/music");
    return response.data;
};