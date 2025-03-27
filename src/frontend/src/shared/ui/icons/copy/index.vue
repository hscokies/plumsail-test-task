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
    default: '#222'
  }
})
</script>

<template>
  <svg :height="height"
       :stroke="color"
       :width="width"
       fill="none"
       stroke-linecap="round"
       stroke-linejoin="round"
       stroke-width="2"
       xmlns="http://www.w3.org/2000/svg">
    <rect height="13" rx="2" ry="2" width="13" x="9" y="9"/>
    <path d="M5 15H4a2 2 0 0 1-2-2V4a2 2 0 0 1 2-2h9a2 2 0 0 1 2 2v1"/>
  </svg>
</template>

<style scoped>

</style>