<template>

<div class="h-[80px] min-w-[50px] flex flex-col justify-center items-center group select-common">
    <img class="h-[24px] w-[24px] mb-2 selected-logo-img select-transition whitespace-nowrap" 
        :src ="category.imageUrl" 
        alt="icon">
    <h5 class="text-xs font-medium selected-text select-transition whitespace-nowrap">{{ category.name }}</h5>
    <div class="mt-[10px] h-[2px] w-4/5 selected-underline select-transition whitespace-nowrap"></div>
</div>

</template>

<script setup lang="ts">
import type { Category } from '../models/Category';


const props = defineProps({
    category: {
        type: Object as () => Category,
        required: true
    }
});
</script>