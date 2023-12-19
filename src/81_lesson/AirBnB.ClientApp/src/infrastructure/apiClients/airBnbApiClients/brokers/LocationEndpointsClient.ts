import type { Guid } from "guid-typescript";
import type { ApiClientBase } from "../../apiClientBase/ApiClientBase";
import type { Location } from "@/modules/locations/models/Location";

export class LocationEndpointsClient {
    private readonly client: ApiClientBase;

    constructor(clinet: ApiClientBase) {
        this.client = clinet;
    }

    public async getLocations() {
        return await this.client.getAsync<Array<Location>>('api/locations')
    }

    public async getLocationsByCategoryIdAsync(id: Guid) {
        return await this.client.getAsync<Array<Location>>(`api/locations/${id}:guid`);
    }
}