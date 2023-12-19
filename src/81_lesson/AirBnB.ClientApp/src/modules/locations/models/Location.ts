import type { Guid } from "guid-typescript";

export class Location {
    public id!: Guid
    public name!: string;
    public imageUrl!: string;
    public price!: number;
    public rating!: number;
}