<template>

<article class="mt-[20px] bg-defaultBackground content-padding">

    <div class="flex flex-col items-center justify-center">
        
        <!-- Locations Tab -->
        <locations-tab/>

        <!-- Locations Grid -->
        <locations-grid/>

    </div>

</article>

</template>

<script setup lang="ts">

import LocationsTab from './LocationsTab.vue';
import LocationsGrid from './LocationsGrid.vue';

</script>