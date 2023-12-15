<template>

<div class="flex gap-10 overflow-x-scroll md:gap-12 no-scrollbar">
    
    <location-category-card v-for="category in categories" :category="category"/>
    
</div>

</template>

<script setup lang="ts">

import { AirBnbApiClient } from '@/infrastructure/apiClients/airBnbApiClients/brokers/AirBnbApiClient';
import { Category } from '../models/Category';
import LocationCategoryCard from './LocationCategoryCard.vue';
import {onBeforeMount, ref} from 'vue';

const apiClient = new AirBnbApiClient();

const categories = ref<Category[]>([]);

onBeforeMount(async () => {
   const categoriesResponse = await apiClient.categories.getAsync(); 
   
   if (categoriesResponse.response != null)
        categories.value = categoriesResponse.response;
});



</script>