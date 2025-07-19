import axios from 'axios';
import type { MostPopularSuppliersResponse, Offer } from './Api';

const API_URL = 'http://localhost:5206';

export const getPopularSuppliers: () => Promise<MostPopularSuppliersResponse[]> = async () => {
    const response = await axios.get(`${API_URL}/api/Offer/mostpopularsuppliers`);
    return response.data;
};

export const findOffers: (query?: {
        Stamp?: string;
        Model?: string;
        SupplierId?: string;
      }) => Promise<Offer[]> = async (query) => {

    if (!query?.Stamp ||
        !query?.Model ||
        !query?.SupplierId
    ) {
        query = undefined;
    }

    if (query) {
        const response = await axios.get(`${API_URL}/api/Offer/findoffers?Stamp=${query.Stamp}&Model=${query.Model}&SupplierId=${query.SupplierId}`);
        return response.data;
    }
    else {
        const response = await axios.get(`${API_URL}/api/Offer/findoffers`);
        return response.data;
    }
};