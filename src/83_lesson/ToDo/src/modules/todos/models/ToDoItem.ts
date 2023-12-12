import type { Guid } from "guid-typescript";
import type { IMappable } from "@/infrastructure/mappers/IMappable";

export class ToDoItem implements IMappable<ToDoItem>{

    constructor() {
        this.dueTime = new Date();
        this.reminderTime = new Date();
    }

    id!: Guid;
    title!: string;
    notes!: string;
    isDone!: boolean;
    isFavourite!: boolean;
    dueTime!: Date;
    reminderTime!: Date;

    mapFrom(object: any): ToDoItem {
        this.id = object.id;
        this.title = object.title;
        this.notes = object.notes;
        this.isDone = object.isDone;
        this.isFavourite = object.isFavourite;
        this.dueTime = new Date(object.dueTime);
        this.reminderTime = new Date(object.reminderTime);

        return this;
    }

}