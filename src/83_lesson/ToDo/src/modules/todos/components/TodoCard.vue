<template>

    <div class="flex justify-between w-full p-1 px-3 border rounded-md h-14 task-background theme-text">
       
       <div class="flex gap-x-4">
        
             <!-- Primary Action -->
            <div class="flex items-center">
                <button class="flex items-center justify-center w-5 h-5 border-2 rounded-full theme-border" @click="toggleIsDone">
                    <i class="fa-solid fa-check simple-hover" 
                    :class="{ 'text-successColor opacity-100': todo.isDone, 'text-failedColor': !todo.isDone && (todo.dueTime < Date.now()), }"></i>
                </button>  
            </div>

            <!-- Details -->
            <div class="">
                <h5 class="theme-text">{{todo.title}}</h5>
                
                <div class="flex gap-2 text-sm theme-textSecondary">
                    <p class="opacity-80">{{ DateFormatter.formatHumanize(todo.dueTime) }}</p>
                    <span class="opacity-50">•</span>
                    <p class="opacity-40">{{ DateFormatter.formatHumanize(todo.reminderTime) }}</p>
                </div>
            </div>
       </div>

        <!-- Secondary Actions -->
        
        <div class="flex text-lg gap-x-2">
            <button>
                <i class="fa-solid fa-star"></i>
            </button>

            <button>
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
import { emitKeypressEvents } from 'readline';

const todoApiClient = new TodoApiClient();

const props = defineProps({
    todo: {
        type: Object as () => ToDoItem,
        required: true
    }
});

const emit = defineEmits<{
    editTodo: [id: Guid],
    deleteTodo: [id: Guid]
}>();

const toggleIsDone = async () => {
    todo.value.isDone = !todo.value.isDone;
}

const onEdit = () => {
    emit("editTodo", props.todo?.id);
}

const OnDeleteAsync = async () => {
    const response = await todoApiClient.todos.deleteByIdAsync(props.todo.id);

    if (response.IsSuccess)
        emits("deleteTodo", props.todo.id);
}

</script>