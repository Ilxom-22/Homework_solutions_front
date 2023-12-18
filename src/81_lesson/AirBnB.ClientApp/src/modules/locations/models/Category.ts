import type { Guid } from "guid-typescript";

export class Category {
    public id!: Guid
    public name!: string;
    public imageUrl!: string;
}