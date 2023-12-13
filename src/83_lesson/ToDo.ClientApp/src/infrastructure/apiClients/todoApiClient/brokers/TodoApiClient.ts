import { ApiClientBase } from "../../apiClientBase/ApiClientBase";
import { TodoEndpointsDetails } from "./TodoEndpointsDetails";

export class TodoApiClient {
    private readonly client: ApiClientBase;
    private readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:7063";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        this.todos = new TodoEndpointsDetails(this.client);
    }

    public todos: TodoEndpointsDetails;
}