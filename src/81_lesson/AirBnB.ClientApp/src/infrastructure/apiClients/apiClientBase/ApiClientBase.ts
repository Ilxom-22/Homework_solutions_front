import type { AxiosInstance, AxiosRequestConfig } from "axios";
import axios from 'axios';
import { ClientInterceptors } from "./ClientInterceptors";
import { ApiResponse } from "./ApiResponse";

export class ApiClientBase {
    private readonly client: AxiosInstance;

    constructor(config: AxiosRequestConfig) {
        this.client = axios.create(config);

        ClientInterceptors.registerResponseConverter(this.client);
    }

    public async getAsync<T> (url: string, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return (await this.client.get<ApiResponse<T>>(url, config)).data;
    }

    public async postAsync<T> (url: string, data?: any, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return (await this.client.post(url, data, config)).data;
    }

    public async putAsync<T> (url: string, data?: any, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return (await this.client.put(url, data, config)).data;
    }

    public async deleteAsync<T> (url: string, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return (await this.client.delete(url, config)).data;
    }
}