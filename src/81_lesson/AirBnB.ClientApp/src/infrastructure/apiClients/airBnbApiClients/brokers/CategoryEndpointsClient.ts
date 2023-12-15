import { Category } from "@/modules/locations/models/Category";
import type { ApiClientBase } from "../../apiClientBase/ApiClientBase";

export class CategoryEndpointsClient {
    private readonly client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;   
    }

    public async getAsync() {
        return await this.client.getAsync<Array<Category>>("api/categories");
    }
}