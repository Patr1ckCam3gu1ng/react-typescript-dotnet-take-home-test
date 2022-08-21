import apiClient from "./apiClient";

export const getClients = (search: string = ''): Promise<IClient[]> => {
    return apiClient.get<IClient[]>(`clients?&search=${search}`);
};

export const createClient = (client: IClient): Promise<void> => {
    return apiClient.post<void>("clients", client);
};

export const updateClient = (client: IClient): Promise<void> => {
    return apiClient.put<void>("clients", client);
};
