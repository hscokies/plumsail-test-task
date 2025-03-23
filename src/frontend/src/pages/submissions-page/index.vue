<script setup>
import MockData from './data.json'
import {RouterLink} from "vue-router";
import {Button, BUTTON_SIZE, BUTTON_VARIANTS, Table} from '@/shared/ui'
import {ROUTES} from "@/app/router/index.js";

</script>

<template>
  <div class="submissions-page_root">
    <div class="submissions-page_menu">
      <Button :variant="BUTTON_VARIANTS.Secondary" :size="BUTTON_SIZE.Small" @click="$router.back()">
        Back
      </Button>
    </div>
    <Table
      :columns="MockData.columns"
      :rows="MockData.data"
    />
  </div>
</template>

<style scoped>
.submissions-page_root{
  display: flex;
  flex-flow: column nowrap;
  gap: 8px;
}
</style>