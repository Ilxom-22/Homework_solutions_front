<template>

    <div class="flex flex-col gap-3 overflow-x-scroll no-scrollbar">
        
        <!-- Tasks -->
        <todo-card v-for="todo in todos" :todo="todo" :key="todo.id" @delete-todo="onDeleteTodo"/>
  
        
    </div>

</template>

<script setup lang="ts">

import TodoCard from "./TodoCard.vue"
import type { PropType } from 'vue';
import type { ToDoItem } from "../models/ToDoItem";
import type { Guid } from "guid-typescript"; 

const props = defineProps({
    todos: {
        type: Array as PropType<Array<ToDoItem>>,
        required: true
    }
})

const onDeleteTodo = (id: Guid) => {
    const index = props.todos.findIndex(x => x.id === id);
    if (index !== -1)
        props.todos.splice(index, 1);
}

</script>