<template>

<!-- Location Card -->
<div>
    
    <!-- Location Header -->
    <div class="relative w-full h-auto overflow-hidden aspect-square rounded-xl">
        <img class="object-cover w-full h-full"
            :src="location.imageUrl"
            alt="">
            
        <button class="absolute top-4 right-3">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" aria-hidden="true" role="presentation" focusable="false"
                style="display: block; fill: rgba(0, 0, 0, 0.5); height: 24px; width: 24px; stroke: var(--f-mkcy-f); stroke-width: 2; overflow: visible;">
                <path d="M16 28c7-4.73 14-10 14-17a6.98 6.98 0 0 0-7-7c-1.8 0-3.58.68-4.95 2.05L16 8.1l-2.05-2.05a6.98 6.98 0 0 0-9.9 0A6.98 6.98 0 0 0 2 11c0 7 7 12.27 14 17z"></path>
            </svg>
        </button>
            
    </div>

    <!-- Location Details -->
    <div class="flex justify-between mt-2">
        
        <!-- About -->
        <div class="basis-2/3">
            <h5 class="font-medium line-clamp-1">{{ location.name }}</h5>
            <p class="text-textSecondary line-clamp-1">1-6 Dec</p>
            <h5 class="underline">
                <strong>{{ `$${location.price}` }}</strong> total
            </h5>
        </div>
        
        <!-- Feedback -->    
        <div>
            <div class="flex items-center gap-2 ">
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" aria-hidden="true" role="presentation" focusable="false"
                    style="display: block; height: 12px; width: 12px; fill: currentcolor;">
                    <path fill-rule="evenodd"
                        d="m15.1 1.58-4.13 8.88-9.86 1.27a1 1 0 0 0-.54 1.74l7.3 6.57-1.97 9.85a1 1 0 0 0 1.48 1.06l8.62-5 8.63 5a1 1 0 0 0 1.48-1.06l-1.97-9.85 7.3-6.57a1 1 0 0 0-.55-1.73l-9.86-1.28-4.12-8.88a1 1 0 0 0-1.82 0z"></path>
                </svg>
                <span>{{ location.rating }}</span>
            </div> 
        </div>  
        
    </div>
</div>

</template>

<script setup lang="ts">

import type { Location } from '../models/Location';


const props = defineProps({
   location: {
        type: Object as () => Location,
        required: true
   } 
});

</script>