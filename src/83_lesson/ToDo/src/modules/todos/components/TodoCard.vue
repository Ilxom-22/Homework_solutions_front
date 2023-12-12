<template>

    <div class="flex justify-between w-full p-1 px-3 border rounded-md h-14 task-background theme-text">
       
       <div class="flex gap-x-4">
             <!-- Primary Action -->
            <div class="flex items-center">
                <button class="w-5 h-5 border-2 rounded-full theme-border">
                </button>  
            </div>

            <!-- Details -->
            <div class="">
                <h5 class="theme-text">{{todo.title}}</h5>
                
                <div class="flex gap-2 text-sm theme-textSecondary">
                    <p class="opacity-80">{{ DateFormatter.formatHumanize(todo.dueTime) }}</p>
                    <span class="opacity-50">•</span>
                    <p class="opacity-40">{{ DateFormatter.formatHumanize(todo.reminderTime) }}</p>
                </div>
            </div>
       </div>

        <!-- Secondary Actions -->
        
        <div class="flex text-lg gap-x-2">
            <button>
                <i class="fa-solid fa-star"></i>
            </button>

            <button>
                <i class="fa-solid fa-pen-to-square"></i>
            </button>

            <button>
                <i class="fa-solid fa-trash"></i>
            </button>
        </div>
    
        
        
       
    </div>

</template>

<script setup lang="ts">
import type { ToDoItem } from '../models/ToDoItem';
import { DateFormatter } from "@/infrastructure/services/DateFormatter"


const props = defineProps({
    todo: {
        type: Object as () => ToDoItem,
        required: true
    }
});

</script>