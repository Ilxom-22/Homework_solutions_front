<template>

    <div class="p-20 px-[10%] flex flex-col gap-y-20 w-full h-full justify-between">
         <!-- Todo list -->
         <todo-list :todos="todos"/>

        <!-- Add New Task -->
        <new-todo-form/>
    </div>
   

</template>

<script setup lang="ts">

import TodoList from './TodoList.vue';
import NewTodoForm from './NewTodoForm.vue';
import { onBeforeMount, ref } from "vue";
import { TodoApiClient } from '@/infrastructure/apiClients/todoApiClient/brokers/TodoApiClient';
import type { ToDoItem } from '@/modules/todos/models/ToDoItem';

const todoApiClient = new TodoApiClient();
const todos = ref<ToDoItem[]>([]);

onBeforeMount(async () => {
    await loadTodosAsync();
});

const loadTodosAsync = async () => {
    const todosResponse = await todoApiClient.todos.getAsync();
    if (todosResponse.IsSuccess && todosResponse.response) {
        todos.value = todosResponse.response;
    }
}



</script>