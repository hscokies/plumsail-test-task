<script setup>
defineProps({
  width: {
    type: Number,
    default: 24
  },
  height: {
    type: Number,
    default: 24
  },
  color: {
    type: String,
    default: '#7A5CFA'
  }
})
</script>

<template>
  <svg
      :height="height"
      :stroke="color"
      :width="width"
      fill="none"
      stroke-linecap="round"
      stroke-linejoin="round"
      stroke-width="2"
      xmlns="http://www.w3.org/2000/svg">
    <rect height="18" rx="2" ry="2" width="18" x="3" y="4"/>
    <line x1="16" x2="16" y1="2" y2="6"/>
    <line x1="8" x2="8" y1="2" y2="6"/>
    <line x1="3" x2="21" y1="10" y2="10"/>
  </svg>
</template>

<style scoped>

</style>