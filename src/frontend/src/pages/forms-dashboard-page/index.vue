<script setup>
import {RouterLink} from 'vue-router'
import {ROUTES} from "@/app/router/index.js";
import {BarChart, Link} from '@/shared/ui/icons'
import {Table} from '@/shared/ui'
import MockData from './data.json'

const headers = [
  {
    key: 'id',
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
</script>

<template>
  <Table :columns="headers" :rows="MockData" has-actions>
    <template #data="{ row }">
      <RouterLink :to="`${ROUTES.Form}/${row.id}`" target="_blank" title="Get link">
        <Link/>
      </RouterLink>
      <RouterLink :to="`${ROUTES.Submissions}`" title="Get submissions">
        <BarChart/>
      </RouterLink>
    </template>
  </Table>
</template>

<style scoped>
</style>