<template>

    <div class="fixed top-0 z-10 flex items-center justify-between w-full h-20 border-b content-padding border-borderSecondary bg-defaultBackground text-textPrimary">
        <!-- Main Logo -->
        <main-logo/>

        <!-- Locations Menu -->
        <locations-menu/>

        <!-- Profile Menu -->
        <profile-menu/>
        
        <!-- Locations Filter -->
        <locations-filter/>

        <!-- Bottom Border -->
    </div>

</template>

<script setup lang="ts">

import MainLogo from './icons/MainLogo.vue';
import LocationsMenu from "@/modules/locations/components/LocationsMenu.vue";
import ProfileMenu from '@/modules/locations/components/ProfileMenu.vue';
import LocationsFilter from '@/modules/locations/components/LocationsFilter.vue';

</script>