<template>

    <div class="p-20 px-[10%] flex flex-col gap-y-20 w-full h-full justify-between">
         <!-- Todo list -->
         <todo-list :todos="todos" @editTodo="onEditTodo"/>

        <!-- Add New Task -->
        <new-todo-form @add-new-todo="onAddTodo" :editTodo="editTodo"/>
    </div>
   

</template>

<script setup lang="ts">

import TodoList from './TodoList.vue';
import NewTodoForm from './NewTodoForm.vue';
import { onBeforeMount, ref } from "vue";
import { TodoApiClient } from '@/infrastructure/apiClients/todoApiClient/brokers/TodoApiClient';
import type { ToDoItem } from '@/modules/todos/models/ToDoItem';
import type { Guid } from 'guid-typescript';

const todoApiClient = new TodoApiClient();
const todos = ref<ToDoItem[]>([]);
const editTodo = ref<ToDoItem | null>(null);

onBeforeMount(async () => {
    await loadTodosAsync();
});

const loadTodosAsync = async () => {
    const todosResponse = await todoApiClient.todos.getAsync();
    if (todosResponse.IsSuccess && todosResponse.response) {
        todos.value = todosResponse.response;
    }
}

const onAddTodo = (todo: ToDoItem) => {
    todos.value.push(todo);
}

const onEditTodo = (id: Guid) => {
    const todo = todos.value.find(x => x.id === id);

    if (todo) {
        editTodo.value = todo;
    }
}

</script>