import axios from 'axios';
import {BACKEND_ADDR} from "../environment";

const BASE_URL = `${BACKEND_ADDR}api/items/`;

export const getItems = async (filter) => {

    return await axios.get(BASE_URL + 'get-by-filter', {params: filter})
        .then(response => response.data)
        .catch(error => {
            console.error('error with get items attempt:', error.message);
            throw error;
        });
};

export const overwriteData = async (newItems) => {
    try {
        await axios.post(BASE_URL + 'overwrite-data', newItems);
    } catch (error) {
        console.error('error with overwrite data attempt:', error.message);
        throw error;
    }
};