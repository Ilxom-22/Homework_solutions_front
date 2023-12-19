<template>

<div class="mt-[160px] grid grid-cols-1 place-items-center gap-x-4 gap-y-10 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4">

    <!-- Locations -->
    <location-card v-for="location in locations" :location="location"/>

</div>

</template>

<script setup lang="ts">

import LocationCard from './LocationCard.vue';
import { onBeforeMount, ref } from 'vue';
import { AirBnbApiClient } from '@/infrastructure/apiClients/airBnbApiClients/brokers/AirBnbApiClient';
import { Guid } from 'guid-typescript';
import type { Location } from '../models/Location';

const airBnbApiClient = new AirBnbApiClient();
const locations = ref<Location[]>([]);


onBeforeMount(async () => {
    await loadLocationCardsAsync();
});

const loadLocationCardsAsync = async () => {
    const locationsResponse = await airBnbApiClient.locations.getLocations();
    if (locationsResponse.isSuccess && locationsResponse.response) {
        locations.value = locationsResponse.response;
    }
};

</script>