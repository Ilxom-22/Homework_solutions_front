<template>

    <div>
        <form @submit.prevent="submitAsync" class="w-full">
            <input type="text" v-model="todo.title" placeholder="Add a task" class="input task-background theme-text"/>
        </form>
    </div>

</template>

<script setup lang="ts">

import { TodoApiClient } from '@/infrastructure/apiClients/todoApiClient/brokers/TodoApiClient';
import { ToDoItem } from '../models/ToDoItem';
import { ref } from 'vue';


const todoApiClient = new TodoApiClient();

const todo = ref<ToDoItem>(new ToDoItem());

const emit = defineEmits<{
    addNewTodo: [todo: ToDoItem]
}>();

const createToDoAsync = async () => {
    const response = await todoApiClient.todos.createAsync(todo.value);

    if (response.IsSuccess)
        emit("addNewTodo", response.response!);
    
    return response.IsSuccess;
}

const resetForm = () => {
    todo.value = new ToDoItem();
}

const submitAsync = async () => {
    let result: boolean;

    result = await createToDoAsync();

    if (result) {
        resetForm();
    }
}

</script>