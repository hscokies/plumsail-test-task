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
    <line x1="18" x2="18" y1="20" y2="10"/>
    <line x1="12" x2="12" y1="20" y2="4"/>
    <line x1="6" x2="6" y1="20" y2="14"/>
  </svg>
</template>
