<template>

<!-- Locations Tab-->
<div class="fixed top-0 z-10 flex items-center justify-center w-full gap-4 pt-2 mt-20 bg-white content-padding">
    
    <!-- Location previous pagination -->
    <div class="mb-3">
        <button class="flex items-center justify-center w-8 h-8 border rounded-full border-borderSecondary hover:shadow-xl">
            <svg xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 32 32" 
                aria-hidden="true" 
                role="presentation" 
                focusable="false"
                style="display: block; 
                fill: none; 
                height: 12px; 
                width: 12px; 
                stroke: currentcolor; 
                stroke-width: 5.33333; 
                overflow: visible;">
            <path fill="none" d="M20 28 8.7 16.7a1 1 0 0 1 0-1.4L20 4"></path>
        </svg>
        </button>
    </div>

    <location-categories/>

    <!-- Location next pagination -->
    <div class="mb-3">
        <button class="flex items-center justify-center w-8 h-8 border rounded-full shadow-md border-borderSecondary">
            <svg xmlns="http://www.w3.org/2000/svg" 
                viewBox="0 0 32 32" 
                aria-hidden="true"
                role="presentation"
                focusable="false"
                style="display: block; 
                fill: none; 
                height: 12px; 
                width: 12px; 
                stroke: currentcolor; 
                stroke-width: 5.33333; 
                overflow: visible;">
                <path fill="none" d="m12 4 11.3 11.3a1 1 0 0 1 0 1.4L12 28"></path>
            </svg>
        </button>
    </div>

    <!-- Filters Actions -->
    <div class="w-[500px] hidden lg:flex items-center justify-center pb-3">
            
        <!-- Locations Filter -->
        <button class="flex items-center justify-center w-auto h-12 gap-3 px-4 border rounded-lg border-borderSecondary group">
            <svg class="selected-text text-textSecondary" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" aria-hidden="true"
                role="presentation"
                focusable="false"
                style="display: block; 
                fill: none; 
                height: 16px; 
                width: 16px; 
                stroke: currentcolor; 
                stroke-width: 4; 
                overflow: visible;">
                <path fill="none"
                    d="M7 16H3m26 0H15M29 6h-4m-8 0H3m26 20h-4M7 16a4 4 0 1 0 8 0 4 4 0 0 0-8 0zM17 6a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 20a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 0H3">
                </path>
            </svg>
            
            <span>Filters</span>
        </button>
    </div>   
    
</div>

</template>

<script setup lang="ts">

import LocationCategories from './LocationCategories.vue';

</script>