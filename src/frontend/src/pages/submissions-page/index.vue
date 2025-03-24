<script setup>
import MockData from './data.json'
import {Button, BUTTON_SIZE, BUTTON_VARIANTS, Table} from '@/shared/ui'
</script>

<template>
  <div class="submissions-page_root">
    <div class="submissions-page_menu">
      <Button :size="BUTTON_SIZE.Small" :variant="BUTTON_VARIANTS.Secondary" @click="$router.back()">
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
.submissions-page_root {
  display: flex;
  flex-flow: column nowrap;
  gap: 8px;
}
</style>