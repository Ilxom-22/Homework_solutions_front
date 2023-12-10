<template>

    <div class="h-screen bg-center bg-cover" style="background-image: url('/src/assets/background-photo.jpg');">
       
        <!-- Header -->

        <!-- Content -->
        <todo-container/>
        
    </div>

</template>

<script setup lang="ts">

    import TodoContainer from "@/modules/todos/components/TodoContainer.vue";

</script>