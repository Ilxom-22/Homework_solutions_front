<template>

    <div class="p-20 px-[10%] flex flex-col gap-y-20 w-full h-full justify-between">
         <!-- Todo list -->
         <todo-list/>

        <!-- Add New Task -->
        <new-todo-form/>
    </div>
   

</template>

<script setup lang="ts">

    import TodoList from './TodoList.vue';
    import NewTodoForm from './NewTodoForm.vue';

</script>