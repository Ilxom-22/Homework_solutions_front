<template>

    <div>
        <form @submit.prevent="submitAsync" class="w-full">
            <input type="text" v-model="todo.title" placeholder="Add a task" class="input task-background theme-text"/>
        </form>
    </div>

</template>

<script setup lang="ts">

import { TodoApiClient } from '@/infrastructure/apiClients/todoApiClient/brokers/TodoApiClient';
import { ToDoItem } from '../models/ToDoItem';
import { ref, watch } from 'vue';


const todoApiClient = new TodoApiClient();
const todo = ref<ToDoItem>(new ToDoItem());
const isEditing = ref<boolean>(false);

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
        updateToDoValues(response.response!);

    return response.IsSuccess;
}

const updateToDoValues = (todo: ToDoItem) => {
    props.editTodo!.title = todo.title;
    props.editTodo!.notes = todo.notes;
    props.editTodo!.dueTime = todo.dueTime;
    props.editTodo!.reminderTime = todo.reminderTime;
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

watch(() => props.editTodo, () => {
    if (props.editTodo) {
        isEditing.value = true;
        todo.value = props.editTodo;
    }
});

</script>