<script setup>
import {useQuery} from '@tanstack/vue-query'
import {RouterLink} from 'vue-router'
import {ROUTES} from "@/app/router/index.js";
import {Error, Table, TextField} from '@/shared/ui'
import {ref} from "vue";
import * as submissionsApi from "@/shared/api/submission-api.js";
import {useDebounceFn} from "@vueuse/core";

// imo page for every form would look better

const search = ref();

const {data, isError, error} = useQuery({
  queryKey: ['get-submissions', search],
  queryFn: () => submissionsApi.getAll(search.value)
});

const headers = [
  {
    key: 'formId',
    label: 'Form ID',
  },
  {
    key: 'title',
    label: 'Title',
  },
  {
    key: 'subtitle',
    label: 'Subtitle',
  },
  {
    key: 'id',
    label: 'Interview ID',
  },
  {
    key: 'answers',
    label: 'Answers',
  }
]

const onSearch = useDebounceFn((event) => {
  search.value = event.target.value
}, 1000)
</script>

<template>
  <div class="top-menu">
    <RouterLink :to="ROUTES.Dashboard">
      Go to forms
    </RouterLink>
    <TextField
        id="search-bar"
        :value="search"
        label="Search"
        name="search-bar"
        placeholder="Try typing something..."
        type="text"
        @keyup="onSearch"/>
  </div>
  <Table :columns="headers" :rows="data">
  </Table>
  <Error v-if="isError" :trace-id="error?.traceId"/>
</template>

<style scoped>
.top-menu {
  display: flex;
  flex-flow: column nowrap;
  gap: 30px;
}
</style>