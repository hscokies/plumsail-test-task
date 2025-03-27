<script setup>
import {useQuery} from '@tanstack/vue-query'
import {RouterLink} from 'vue-router'
import {ROUTES} from "@/app/router/index.js";
import {Link} from '@/shared/ui/icons'
import {Error, Table, TextField} from '@/shared/ui'
import {ref} from "vue";
import * as formsApi from "@/shared/api/form-api.js";
import {useDebounceFn} from "@vueuse/core";

const search = ref();

const {data, isError, error} = useQuery({
  queryKey: ['get-forms', search],
  queryFn: () => formsApi.getAll(search.value)
});

const headers = [
  {
    key: 'formId',
    label: 'ID',
  },
  {
    key: 'title',
    label: 'Title',
  },
  {
    key: 'subtitle',
    label: 'Subtitle',
  }
]

const onSearch = useDebounceFn((event) => {
  search.value = event.target.value
  console.log(search.value)
}, 1000)
</script>

<template>
  <div class="top-menu">
    <RouterLink to="/submissions">
      Go to submissions
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
  <Table :columns="headers" :rows="data" has-actions>
    <template #data="{ row }">
      <RouterLink :to="`${ROUTES.Form}/${row.formId}`" target="_blank" title="Get link">
        <Link/>
      </RouterLink>
    </template>
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