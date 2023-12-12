<template>

    <div class="flex flex-col gap-3 overflow-x-scroll no-scrollbar">
        
        <!-- Tasks -->
        <todo-card v-for="todo in todos" :todo="todo" :key="todo.id"/>
  
        
    </div>

</template>

<script setup lang="ts">

import TodoCard from "./TodoCard.vue"
import type { PropType } from 'vue';
import type { ToDoItem } from "../models/ToDoItem";

const props = defineProps({
    todos: {
        type: Array as PropType<Array<ToDoItem>>,
        required: true
    }
})

</script>