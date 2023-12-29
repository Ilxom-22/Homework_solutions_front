<template>

<div class="flex items-center w-full h-12 p-4 task-background gap-x-4 rounded-xl">


<v-form @submit.prevent="submitAsync" class="flex w-full">
    <div class="flex-grow">
        <input type="text" placeholder="Add task" v-model="todo.title"
               class="bg-transparent text-md input focus:outline-none theme-text theme-border">
    </div>
    <div class="flex gap-x-4">

        <!-- Due time picker -->
        <date-time-picker class="absolute bottom-0 right-0 z-20"
                                  v-if="showDueTimePicker"
                                  @onClose="toggleDueTimePicker"
                                  :min-date="minDate"
                                  v-model="todo.dueTime"/>
                <button ref="dueTimeButton" type="button" class="relative flex items-center justify-center text-2xl"
                        @click="toggleDueTimePicker">
                    <i class="mr-1 fa-regular btn-hover fa-calendar theme-text theme-icon"></i>
                </button>

        <!-- Reminder time picker -->
        <date-time-picker class="absolute bottom-0 right-0 z-20"
                                  v-if="showReminderTimePicker"
                                  @onClose="toggleReminderTimePicker"
                                  :min-date="minDate"
                                  :max-date="todo.dueTime"
                                  v-model="todo.reminderTime"/>
                <button type="button" class="relative flex items-center justify-center text-2xl"
                        @click="toggleReminderTimePicker">
                    <i class="mr-1 fa-regular btn-hover fa-bell theme-text theme-icon"></i>
                </button>

        <button type="submit" class="theme-text theme-icon" @click="submitAsync">Submit</button>
    </div>

</v-form>
</div>

</template>

<script setup lang="ts">

import { TodoApiClient } from '@/infrastructure/apiClients/todoApiClient/brokers/TodoApiClient';
import { ToDoItem } from '../models/ToDoItem';
import { ref, watch } from 'vue';
import { Utils } from '@/infrastructure/extensions/ObjectExtensions';
import DateTimePicker from "@/common/components/DateTimePicker.vue";


const todoApiClient = new TodoApiClient();
const todo = ref<ToDoItem>(new ToDoItem());
const isEditing = ref<boolean>(false);
const showDueTimePicker = ref<boolean>(false);
const showReminderTimePicker = ref<boolean>(false);
const minDate = new Date();

const props = defineProps({
    editTodo: {
        type: Object as () => ToDoItem | null,
        required: false,
        default: null
    }
});

const emit = defineEmits<{
    addNewTodo: [todo: ToDoItem]
}>();

const createToDoAsync = async () => {
    const response = await todoApiClient.todos.createAsync(todo.value);

    if (response.IsSuccess)
        emit("addNewTodo", response.response!);
    
    return response.IsSuccess;
}

const updateToDoAsync = async () => {
    const response = await todoApiClient.todos.updateAsync(todo.value);

    if (response.IsSuccess)
        Object.assign(props.editTodo!, todo.value);

    return response.IsSuccess;
}

const resetForm = () => {
    todo.value = new ToDoItem();
}

const submitAsync = async () => {
    let result: boolean;

    if (isEditing.value) {
        result = await updateToDoAsync();
        isEditing.value = false;
    }
    else {
        result = await createToDoAsync();
    }
       
    if (result) {
        resetForm();
    }
}

const toggleDueTimePicker = () => {
    showDueTimePicker.value = !showDueTimePicker.value;
    showReminderTimePicker.value = false;
}

const toggleReminderTimePicker = () => {
    showReminderTimePicker.value = !showReminderTimePicker.value;
    showDueTimePicker.value = false;
}

watch(() => props.editTodo, () => {
    if (props.editTodo) {
        isEditing.value = true;
        todo.value = Utils.deepClone(props.editTodo);
        todo.value.dueTime = new Date(props.editTodo.dueTime);
        todo.value.reminderTime = new Date(props.editTodo.reminderTime);
    }
});

</script>