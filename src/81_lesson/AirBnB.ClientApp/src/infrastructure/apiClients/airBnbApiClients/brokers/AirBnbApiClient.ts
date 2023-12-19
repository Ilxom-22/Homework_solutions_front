import { ApiClientBase } from "../../apiClientBase/ApiClientBase";
import { CategoryEndpointsClient } from "./CategoryEndpointsClient";
import { LocationEndpointsClient } from "./LocationEndpointsClient";

export class AirBnbApiClient {
    private readonly client: ApiClientBase;
    private readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:7104/";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        this.categories = new CategoryEndpointsClient(this.client);
        this.locations = new LocationEndpointsClient(this.client);
    }

    public readonly categories: CategoryEndpointsClient;
    public readonly locations: LocationEndpointsClient;
}