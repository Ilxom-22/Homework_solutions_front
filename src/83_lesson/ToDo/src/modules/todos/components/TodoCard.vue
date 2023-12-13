<template>

    <div class="flex justify-between w-full p-1 px-3 border rounded-md h-14 task-background theme-text">
       
       <div class="flex gap-x-4">
        
             <!-- Primary Action -->
            <div class="flex items-center">
                <button class="flex items-center justify-center w-5 h-5 border-2 rounded-full theme-border" 
                    :class="{'border-red-500': !todo.isDone && isOverdue}" @click="toggleIsDone" :disabled="isOverdue">
                    <i v-if="todo.isDone || (!todo.isDone && !isOverdue)" class="fa-solid fa-check simple-hover"
                        :class="{ 'text-successColor opacity-100': todo.isDone }"></i>
                    <i v-if="(!todo.isDone && isOverdue)" class="text-red-500 fa-solid fa-xmark"></i>
                </button>  
            </div>

            <!-- Details -->
            <div class="">
                <h5 class="theme-text line-clamp-1">{{todo.title}}</h5>
                
                <div class="flex gap-2 text-sm theme-textSecondary">
                    <p class="opacity-80" :class="{'text-red-500': isOverdue}">
                        <i class="mr-1 fa-regular fa-calendar" :class="{'text-red-500': isOverdue}"></i>
                        {{ DateFormatter.formatHumanize(todo.dueTime) }}
                    </p>
                    <span class="opacity-50">•</span>
                    <p class="opacity-40">
                        <i class="mr-1 fa-regular fa-bell"></i>
                        {{ DateFormatter.formatHumanize(todo.reminderTime) }}
                    </p>
                </div>
            </div>
       </div>

        <!-- Secondary Actions -->
        
        <div class="flex text-lg gap-x-2">
            <button @click="toggleIsFavourite">
                <i class="fa-regular fa-star" :class="todo.isFavorite ? 'fa-solid' : 'fa-regular'"></i>
            </button>

            <button @click="onEdit">
                <i class="fa-solid fa-pen-to-square"></i>
            </button>

            <button @click="OnDeleteAsync">
                <i class="fa-solid fa-trash"></i>
            </button>
        </div>
    
        
        
       
    </div>

</template>

<script setup lang="ts">
import { TodoApiClient } from '@/infrastructure/apiClients/todoApiClient/brokers/TodoApiClient';
import type { ToDoItem } from '../models/ToDoItem';
import { DateFormatter } from "@/infrastructure/services/DateFormatter"
import type { Guid } from 'guid-typescript';
import { Utils } from "@/infrastructure/extensions/ObjectExtensions";
import { computed } from "vue";

const todoApiClient = new TodoApiClient();

const props = defineProps({
    todo: {
        type: Object as () => ToDoItem,
        required: true
    }
});

const emits = defineEmits<{
    editTodo: [id: Guid],
    deleteTodo: [id: Guid]
}>();

const toggleIsDone = async () => {
    const clonedTodo = Utils.deepClone(props.todo);
    clonedTodo.isDone = !clonedTodo.isDone;

    const response = await todoApiClient.todos.updateAsync(clonedTodo);
    if (response.IsSuccess)
        Object.assign(props.todo, clonedTodo);
}

const toggleIsFavourite = async () => {
    const clonedTodo = Utils.deepClone(props.todo);
    clonedTodo.isFavorite = !clonedTodo?.isFavorite;

    const response = await todoApiClient.todos.updateAsync(clonedTodo);
    if (response.IsSuccess)
        Object.assign(props.todo, clonedTodo);
}

const onEdit = () => {
    emits("editTodo", props.todo?.id);
}

const OnDeleteAsync = async () => {
    const response = await todoApiClient.todos.deleteByIdAsync(props.todo.id);

    if (response.IsSuccess)
        emits("deleteTodo", props.todo.id);
}

const isOverdue = computed(() => new Date(props.todo.dueTime) < new Date());

</script>